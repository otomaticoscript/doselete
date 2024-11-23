using Doselete.Domain.Repository.Query;
using Doselete.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Doselete.Domain.Repository.Data
{
    public interface ITemplateFieldData
    {
        public Task<List<TemplateField>> GetFieldsAsync(int IdTemplate);       
        public Task InsertFieldAsync(TemplateField[] fields);
        public Task UpdateFieldAsync(TemplateField[] fields);
        public Task DeleteFieldAsync(int IdField);
        public Task DeleteFieldByIdTemplateAsync(int IdTemplate);
    }
    public class TemplateFieldData : ITemplateFieldData
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public TemplateFieldData(IConfiguration configuration, IDbConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
            _connection.ConnectionString = _configuration.GetConnectionString("dbSQL");
        }
		
		#region TemplateField
        public async Task<List<TemplateField>> GetFieldsAsync(int IdTemplate) 
        {
            List<TemplateField> result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<TemplateField>(TemplateFieldQueries.GetField,new {IdTemplate})).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateFieldData.GetFieldsAsync:", ex);
            }
            return result;
        }
		
        public async Task InsertFieldAsync(TemplateField[] fields)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateFieldQueries.InsertField, fields);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateFieldData.InsertFieldAsync:", ex);
            }
        }
		
        public async Task UpdateFieldAsync(TemplateField[] fields)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateFieldQueries.UpdateField, fields);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateFieldData.UpdateTemplateFieldAsync:", ex);
            }
        }
		
		public async Task DeleteFieldAsync(int IdField)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateFieldQueries.DeleteField, new { IdField = IdField });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateFieldData.DeleteFieldAsync:", ex);
            }
        }
        public async Task DeleteFieldByIdTemplateAsync(int IdTemplate)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateFieldQueries.DeleteFieldByIdTemplate, new { IdTemplate = IdTemplate });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateFieldData.DeleteFieldByIdTemplateAsync:", ex);
            }
        }
		#endregion
    }
}
