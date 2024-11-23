using Doselete.Domain.Entity;
using Doselete.Domain.Repository.Data;

namespace Doselete.Application.UserCase
{
    public interface ITemplateManager
    {
        public Task<List<Template>> GetTemplates();
        public Task<Template> GetTemplatesById(int id);
        public Task<List<Template>> GetTemplatesByName(string name);
        public Task SetTemplate(Template template);
        public Task RemoveTemplate(int idTemplate);

        public Task<List<TemplateField>> GetFields(int idTemplate);
        public Task SetFields(TemplateField[] fields);
        public Task RemoveField(int IdField);

        public Task<List<TemplateAllowedChildren>> GetChildrens(int idTemplate);
        public Task<List<TemplateAllowedChildren>> GetChildrenByIdNode(int idNode);
        
        public Task SetChildrens(TemplateAllowedChildren[] childrens);
        public Task RemoveChildren(int idAllowed);
    }

    public class TemplateManager : ITemplateManager
    {
        private readonly ITemplateData _templateData;
        private readonly ITemplateFieldData _templateFieldData;
        private readonly ITemplateAllowedChildrenData _templateAllowedChildrenData;
        public TemplateManager(ITemplateData templateData, ITemplateFieldData templateFieldData, ITemplateAllowedChildrenData templateAllowedChildrenData)
        {
            _templateData = templateData;
            _templateFieldData = templateFieldData;
            _templateAllowedChildrenData = templateAllowedChildrenData;
        }

        #region Template
        public async Task<List<Template>> GetTemplates()
        {
            return await _templateData.GetTemplatesAsync();
        }
        public async Task<List<Template>> GetTemplatesByName(string name) { 
            return await _templateData.GetTemplatesByNameAsync(name);
        }
        public async Task<Template> GetTemplatesById(int id) { 
            return await _templateData.GetTemplatesByIdAsync(id);
        }
        public async Task SetTemplate(Template template)
        {
            if (template.Id == null)
            {
                await _templateData.InsertTemplateAsync(template);
            }
            else
            {
                await _templateData.UpdateTemplateAsync(template);
            }
        }

        public async Task RemoveTemplate(int idTemplate)
        {
            await _templateFieldData.DeleteFieldByIdTemplateAsync(idTemplate);
            await _templateAllowedChildrenData.DeleteChildrenByIdTemplateAsync(idTemplate);
            await _templateData.DeleteTemplateAsync(idTemplate);
        }
        #endregion
        #region Field
        public async Task<List<TemplateField>> GetFields(int idTemplate)
        {
            return await _templateFieldData.GetFieldsAsync(idTemplate);
        }
        public async Task SetFields(TemplateField[] fields)
        {
            TemplateField[] insert = fields.Where(w => w.Id == null).ToArray();
            TemplateField[] update = fields.Where(w => w.Id != null).ToArray();
            if (insert.Count() > 0)
            {
                await _templateFieldData.InsertFieldAsync(insert);
            }
            if (update.Count() > 0)
            {
                await _templateFieldData.UpdateFieldAsync(update);
            }
        }

        public async Task RemoveField(int IdField)
        {
            await _templateFieldData.DeleteFieldAsync(IdField);
        }
        #endregion

        #region Children
        public async Task<List<TemplateAllowedChildren>> GetChildrens(int idTemplate)
        {
            return await _templateAllowedChildrenData.GetChildrensAsync(idTemplate);
        }
        public async Task<List<TemplateAllowedChildren>> GetChildrenByIdNode(int idNode)
        {
            return await _templateAllowedChildrenData.GetChildrenByIdNodeAsync(idNode);
        }
        public async Task SetChildrens(TemplateAllowedChildren[] childrens)
        {
            int[]parents = childrens.Select(s => s.IdTemplateParent).ToArray<int>();
            List<TemplateAllowedChildren> myChildren = await _templateAllowedChildrenData.GetChildrensAsync(parents);
            List<TemplateAllowedChildren> insert = new List<TemplateAllowedChildren>();
            if (myChildren.Count() > 0)
            {
                List<TemplateAllowedChildren> update = new List<TemplateAllowedChildren>();
                childrens.ToList().ForEach((child) =>
                {
                    if (myChildren.Any(a => a.IdTemplate == child.IdTemplate && a.IdTemplateParent == child.IdTemplateParent))
                    {
                        update.Add(child);
                    }
                    else
                    {
                        insert.Add(child);
                    }
                });
                if (update.Count() > 0)
                {
                    await _templateAllowedChildrenData.UpdateChildrenAsync(update.ToArray());
                }
            }else{
                insert = childrens.ToList();   
            }
            if (insert.Count() > 0)
            {
                await _templateAllowedChildrenData.InsertChildrenAsync(insert.ToArray());
            }
            
        }
        public async Task RemoveChildren(int idAllowed)
        {
            await _templateAllowedChildrenData.DeleteChildrenAsync(idAllowed);
        }

        #endregion
    }
}