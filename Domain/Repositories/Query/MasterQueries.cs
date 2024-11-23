using System.Security.Cryptography.X509Certificates;

namespace Doselete.Domain.Repository.Query
{
    class MasterQueries
    {
        public const string GetMaster = "SELECT * FROM master ORDER BY Modify DESC";
        public const string GetMasterbyName = "SELECT * FROM master Where name like @Name";
        public const string InsertMaster = @"INSERT INTO master (Name, `Create`, Modify) VALUES (@Name, CURRENT_DATE(), CURRENT_DATE());SELECT LAST_INSERT_ID();";
        public const string UpdateMaster = @"UPDATE master SET Name = @Name, Modify = CURRENT_DATE() WHERE Id = @Id;";
        public const string UpdateMasterModify = "UPDATE master  SET Modify = CURRENT_DATE() WHERE Id = @IdMaster";
        public const string DeleteMaster = @"DELETE FROM master  WHERE Id = @IdMaster;";
        public const string GetOptions = "SELECT * FROM master_option WHERE IdMaster = @IdMaster ORDER BY Place";
        public const string InsertOption = "INSERT INTO master_option (IdMaster, `Key`, `Value`, Place) VALUES ( @IdMaster, @Key, @Value, @Place)";
        public const string UpdatetOption = "UPDATE master_option SET `Key` = @Key, `Value` =  @Value, Place = @Place WHERE Id = @Id;";
        public const string DeleteOptionByIdOption = @"DELETE FROM master_option WHERE Id = @Id;";
        public const string DeleteOptionByIdMaster = @"DELETE FROM master_option WHERE IdMaster = @IdMaster;";
    }
}