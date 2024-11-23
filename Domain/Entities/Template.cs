namespace Doselete.Domain.Entity
{
    public class Template
    {
        public int? Id { get; set; }
        public String Name { get; set; } = "";
        public String AttributeName { get; set; } = "";
        public DateTime? Create { get; set; } = DateTime.UtcNow;
        public DateTime? Modify { get; set; } = DateTime.UtcNow;

    }
    public class TemplateField
    {
        public int? Id { get; set; }
        public int IdTemplate { get; set; }
        public int IdType { get; set; }
        public int? IdMaster { get; set; }
        public string Name { get; set; } = "";
        public string AttributeName { get; set; } = "";
        public string? DefaultValue { get; set; } = "";
        public bool Required { get; set; } = false;
        public int Place { get; set; } = 0;

    }
    public class TemplateAllowedChildren
    {
        public int? Id { get; set; }
        public int IdTemplate { get; set; }
        public int IdTemplateParent { get; set; }
        public int MaxAllowed { get; set; } = 0;

    }
}