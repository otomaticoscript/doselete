namespace Doselete.Domain.Entity
{
    public class Node
    {
        public int? Id { get; set; }
        public int IdTemplate { get; set; }
        public String Name { get; set; } = "";
        public String JsonValue { get; set; } = "";
        public DateTime? Modify { get; set; } = DateTime.UtcNow;

    }
    public class NodeRoot:Node
    {
        public String NameTemplate { get; set; } = "";
    }
    public class NodeList:NodeRoot
    {
        public int? IdNodeRoot { get; set; }
        public int? IdNodeParent { get; set; }
        public string JsonName { get; set; } = "";
        public int Place { get; set; } = 0;
    }

    public class NodeRelation
    {
        public int Id { get; set; }
        public int? Place { get; set; }
        public int IdNode { get; set; }
        public int IdNodeParent { get; set; }
        public int IdNodeRoot { get; set; }
    }
}