namespace Doselete.Domain.Repository.Query
{
    class TemplateQueries
    {
        public const string GetTemplate = "SELECT * FROM template";
        public const string GetTemplatebyId = "SELECT * FROM template WHERE Id = @Id;";
        public const string GetTemplatebyName = "SELECT * FROM template WHERE name like @Name;";
        public const string InsertTemplate = @"INSERT INTO template (Name, AttributeName,`Create`,Modify) VALUES (@Name, @AttributeName, CURRENT_DATE(), CURRENT_DATE());SELECT LAST_INSERT_ID();";
        public const string UpdateTemplate = @"UPDATE template SET Name = @Name, AttributeName = @AttributeName, Modify = CURRENT_DATE() WHERE Id = @Id;";
        public const string DeleteTemplate = @"DELETE FROM template  WHERE Id = @IdTemplate;";
    }
}