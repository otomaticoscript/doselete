namespace Doselete.Domain.Repository.Query
{
    class TVMazeQueries
    {
        public const string GetByIdRoot = "SELECT * FROM tvmaze WHERE IdRoot =  @IdRoot";
        public const string GetByIdProduct = "SELECT * FROM tvmaze WHERE Id = @Id";
        public const string Insert = @"INSERT INTO tvmaze (Id, Name,`Type`, Status, Genre, Language, Country, Runtime, IdRoot) VALUES (@Id, @Name, @Type, @Status, @Genre, @Language, @Country, @Runtime, @IdRoot);";
        /*
        public const string UpdateField = @"UPDATE tvmaze SET Name = @Name, AttributeName = @AttributeName, Required = @Required, Place = @Place, IdTemplate = @IdTemplate, IdType = @IdType, IdMaster = @IdMaster, DefaultValue = @DefaultValue WHERE Id = @Id;";
        public const string DeleteField = @"DELETE FROM tvmaze  WHERE Id = @IdField;";
        public const string DeleteFieldByIdTemplate = @"DELETE FROM tvmaze  WHERE IdTemplate = @IdTemplate;";
        */
    }
}