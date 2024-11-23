namespace Doselete.Domain.Entity
{
    public class Master
    {
        public int? Id { get; set; }
        public String Name { get; set; } = "";
        public DateTime? Create { get; set; } = DateTime.UtcNow;
        public DateTime? Modify { get; set; } = DateTime.UtcNow;

    }
    public class MasterOption
    {
        public int? Id { get; set; }
        public int IdMaster { get; set; }
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
        public int Place { get; set; } = 0;

    }
}