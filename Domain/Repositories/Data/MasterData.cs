using System.Data;
using Dapper;
using Doselete.Domain.Entity;
using Doselete.Domain.Repository.Query;
using Microsoft.Extensions.Configuration;

namespace Doselete.Domain.Repository.Data
{
    public interface IMasterData
    {
        public Task<List<Master>> GetMastersAsync();
        public Task<List<Master>> GetMastersByNameAsync(string Name);
        public Task InsertMasterAsync(Master master);
        public Task UpdateMasterAsync(Master master);
        public Task DeleteMasterAsync(int IdMaster);
		
		//Option Sector
		public Task<List<MasterOption>> GetMasterOptionAsync(int IdMaster);
		public Task InsertOptionAsync(MasterOption[] option);
		public Task UpdateOptionAsync(MasterOption[] option);
        public Task DeleteOptionsByIdMasterAsync(int IdMaster);
        public Task DeleteOptionAsync(int IdOption);
    }
    public class MasterData : IMasterData
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public MasterData(IConfiguration configuration, IDbConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
            _connection.ConnectionString = _configuration.GetConnectionString("dbSQL");
        }
		
		#region Master
        public async Task<List<Master>> GetMastersAsync()
        {
            List<Master> result ;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<Master>(MasterQueries.GetMaster)).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.GetMasterAsync:", ex);
            }
            return result;
        }
        public async Task<List<Master>> GetMastersByNameAsync(string Name)
        {
            List<Master> result = new List<Master>();
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<Master>(MasterQueries.GetMasterbyName, new { Name = $@"%{Name}%" })).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.GetMastersbyLikeNameAsync:", ex);
            }
            return result;
        }

        public async Task InsertMasterAsync(Master master)
        {
            try
            {
                _connection.Open();
                master.Id = await _connection.ExecuteAsync(MasterQueries.InsertMaster, master);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.InsertMasterAsync:", ex);
            }
        }
		
        public async Task UpdateMasterAsync(Master master)
        {
            try
            {
                _connection.Open();
                master.Modify = DateTime.UtcNow;
                await _connection.ExecuteAsync(MasterQueries.UpdateMaster, master);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.UpdateMasterAsync:", ex);
            }
        }
		
		public async Task DeleteMasterAsync(int IdMaster)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(MasterQueries.DeleteMaster, new { IdMaster });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.DeleteMasterAsync:", ex);
            }
        }
		#endregion
		
		#region Option
        public async Task<List<MasterOption>> GetMasterOptionAsync(int IdMaster)
        {
            List<MasterOption> result;
            try
            {
                result = (await _connection.QueryAsync<MasterOption>(MasterQueries.GetOptions,new {IdMaster})).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.GetMasterOptionAsync:", ex);
            }
            return result;
        }
		
        public async Task InsertOptionAsync(MasterOption[] option)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(MasterQueries.InsertOption, option);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.InsertOptionAsync:", ex);
            }
        }

        public async Task UpdateOptionAsync(MasterOption[] option)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(MasterQueries.UpdatetOption, option);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.UpdateOptionAsync:", ex);
            }
        }
		public async Task DeleteOptionsByIdMasterAsync(int IdMaster)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(MasterQueries.DeleteOptionByIdMaster, new { IdMaster });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.DeleteOptionsByIdMasterAsync:", ex);
            }
        }
		public async Task DeleteOptionAsync(int Id)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(MasterQueries.DeleteOptionByIdOption, new {Id});
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD MasterData.DeleteOptionAsync:", ex);
            }
        }
		#endregion
    }
}
