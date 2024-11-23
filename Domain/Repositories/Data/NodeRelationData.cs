using Doselete.Domain.Repository.Query;
using Doselete.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Doselete.Domain.Repository.Data
{
    public interface INodeRelationData
    {
        public Task<List<NodeRelation>> GetNodeRelationByIdNodeRootAsync(int IdNode);
        public Task<List<NodeRelation>> GetNodeRelationByIdNodeParentAsync(int IdNode);
        public Task<NodeRelation?> GetNodeRelationByIdNodeAsync(int IdNode);
        public Task InsertNodeRelationAsync(NodeRelation node);
        public Task UpdateNodeRelationAsync(NodeRelation node);
        public Task DeleteNodeRelationAsync(int IdNode);
        public Task DeleteNodeRelationByIdNodeRootAsync(int IdNode);

    }
    public class NodeRelationData : INodeRelationData
    {
        private readonly IDbConnection _connection;
        public NodeRelationData(IConfiguration configuration, IDbConnection connection)
        {
            _connection = connection;
            _connection.ConnectionString = configuration.GetConnectionString("dbSQL");
        }

        public async Task<List<NodeRelation>> GetNodeRelationByIdNodeRootAsync(int IdNode)
        {
            List<NodeRelation> result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<NodeRelation>(NodeRelationQueries.GetNodeRelationByIdNodeRoot, new { IdNode })).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.GetNodeRelationByIdNodeRootAsync:", ex);
            }
            return result;
        }
        public async Task<NodeRelation?> GetNodeRelationByIdNodeAsync(int IdNode){
            NodeRelation? result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<NodeRelation>(NodeRelationQueries.GetNodeRelation, new { IdNode })).FirstOrDefault();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.GetNodeRelationByIdNodeRootAsync:", ex);
            }
            return result;
        }
        public async Task<List<NodeRelation>> GetNodeRelationByIdNodeParentAsync(int IdNode)
        {
            List<NodeRelation> result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<NodeRelation>(NodeRelationQueries.GetNodeRelationByIdNodeParent, new { IdNode })).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.GetNodeRelationByIdNodeParentAsync:", ex);
            }
            return result;
        }
        public async Task InsertNodeRelationAsync(NodeRelation node)
        {
            
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeRelationQueries.InsertNodeRelation, node);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.InsertNodeRelationAsync:", ex);
            }
        }

        public async Task UpdateNodeRelationAsync(NodeRelation node)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeRelationQueries.UpdateNodeRelation, node);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.UpdateNodeAsync:", ex);
            }
        }
        public async Task DeleteNodeRelationAsync(int IdNode)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeRelationQueries.DeleteNodeRelationByIdNodeParent, new { IdNode });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.DeleteNodeRelationAsync:", ex);
            }
        }
        public async Task DeleteNodeRelationByIdNodeRootAsync(int IdNode)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeRelationQueries.DeleteNodeRelationByIdNodeRoot, new { IdNode });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeRelationData.DeleteNodeRelationByIdNodeRootAsync:", ex);
            }
        }
    }
}
