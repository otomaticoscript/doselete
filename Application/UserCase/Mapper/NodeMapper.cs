using System.Text;
using Doselete.Domain.Entity;
using Newtonsoft.Json.Linq;


namespace Doselete.Application.UserCase.Mapper
{
    public class NodeMapper
    {
        public static Tree<NodeList> MapperTree(List<NodeList> list)
        {
            var root = list.FirstOrDefault(r => r.IdNodeParent == null);
            var mapper = new Tree<NodeList>(root);
            Deep(mapper, list, root.Id.Value);
            return mapper;
        }

        private static void Deep(Tree<NodeList> mapper, List<NodeList> list, int Parent)
        {
            mapper.children = list.Where(f => f.IdNodeParent == Parent).Select(s => new Tree<NodeList>(s)).ToList<Tree<NodeList>>();
            mapper.children.ForEach(children =>
            {
                Deep(children, list, children.element.Id.Value);
            });
        }
        public static async Task<String> MapperJsonByTree(Tree<NodeList> tree, ITemplateManager _template)
        {

            var sb = new StringBuilder();
            var templateField = await _template.GetFields(tree.element.IdTemplate);
            var template = await _template.GetTemplatesById(tree.element.IdTemplate);
            if (!String.IsNullOrEmpty(template.AttributeName))
            {
                sb.Append($"\"{template.AttributeName}\":");
            }

            sb.Append("{");
            if (!String.IsNullOrEmpty(tree.element.JsonValue))
            {
                JObject nodeJson = JObject.Parse(tree.element.JsonValue);
                sb.Append(parseTreeJson(nodeJson, templateField));
            }

            if (tree.children.Count > 0)
            {
                for (int index = 0; index < tree.children.Count; index++)
                {
                    var child = tree.children[index];
                    var str = await MapperJsonByTree(child, _template);
                    if (index > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(str.ToString());
                }
            }

            sb.Append("}");
            return sb.ToString().Replace(",}", "}");
        }
        private static String parseTreeJson(JObject nodeJson, List<TemplateField> templateField)
        {
            String jsonStr = "";
            for (int index = 0; index < templateField.Count; index++)
            {
                var field = templateField[index];
                string key = char.ToUpper(field.AttributeName.First()) + field.AttributeName.Substring(1);
                var value = nodeJson[key];
                if (value == null)
                {
                    value = field.DefaultValue ?? "";
                }
                jsonStr += $"\"{field.AttributeName}\":";
                switch (field.IdType)
                {
                    case (int)Enums.FieldTypes.Boolean:
                    case (int)Enums.FieldTypes.SeleccionMultiple:
                        jsonStr += $"{value}";
                        break;
                    case (int)Enums.FieldTypes.Numerico:
                        jsonStr += $"{value.ToString().Replace(",", ".")}";
                        break;
                    case (int)Enums.FieldTypes.Texto:
                        jsonStr += $"\"{System.Web.HttpUtility.JavaScriptStringEncode(value.ToString())}\"";
                        break;
                    case (int)Enums.FieldTypes.Seleccion:
                    case (int)Enums.FieldTypes.Recurso:
                        jsonStr += $"\"{value}\"";
                        break;
                    default:
                        jsonStr += $"null";
                        break;
                }
                jsonStr += ",";
            }
            return jsonStr;
        }
    }

    public class Tree<T>
    {
        public Tree(T parent)
        {
            this.element = parent;
        }
        public T element;
        public List<Tree<T>> children;

    }
}
