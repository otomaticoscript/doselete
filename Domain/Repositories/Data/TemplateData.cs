using Doselete.Domain.Repository.Query;
using Doselete.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Doselete.Domain.Repository.Data
{
    public interface ITemplateData
    {
        public Task<List<Template>> GetTemplatesAsync();       
        Task<Template> GetTemplatesByIdAsync(int id);
        public Task<List<Template>> GetTemplatesByNameAsync(string Name);
        public Task InsertTemplateAsync(Template template);
        public Task UpdateTemplateAsync(Template template);
        public Task DeleteTemplateAsync(int IdTemplate);
    }
    public class TemplateData : ITemplateData
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public TemplateData(IConfiguration configuration, IDbConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
            _connection.ConnectionString = _configuration.GetConnectionString("dbSQL");
        }
		
		#region Template
        public async Task<List<Template>> GetTemplatesAsync()
        {
            List<Template> result = new List<Template>();
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<Template>(TemplateQueries.GetTemplate)).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.GetTemplateAsync:", ex);
            }
            return result;
        }
        public async Task<Template> GetTemplatesByIdAsync(int Id)
        {
            Template result;
            try
            {
                _connection.Open();
                result = await _connection.QueryFirstOrDefaultAsync<Template>(TemplateQueries.GetTemplatebyId, new { Id })?? new Template();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.GetTemplatesbyLikeNameAsync:", ex);
            }
            return result;
        }
        public async Task<List<Template>> GetTemplatesByNameAsync(string Name)
        {
            List<Template> result = new List<Template>();
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<Template>(TemplateQueries.GetTemplatebyName, new { Name = $@"%{Name}%" })).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.GetTemplatesbyLikeNameAsync:", ex);
            }
            return result;
        }
		
        public async Task InsertTemplateAsync(Template template)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateQueries.InsertTemplate, template);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.InsertTemplateAsync:", ex);
            }
        }
		
        public async Task UpdateTemplateAsync(Template template)
        {
            try
            {
                _connection.Open();
                template.Modify = DateTime.UtcNow;
                await _connection.ExecuteAsync(TemplateQueries.UpdateTemplate, template);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.UpdateTemplateAsync:", ex);
            }
        }
		
		public async Task DeleteTemplateAsync(int IdTemplate)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TemplateQueries.DeleteTemplate, new { IdTemplate = IdTemplate });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TemplateData.DeleteTemplateAsync:", ex);
            }
        }
		#endregion
    }
}
