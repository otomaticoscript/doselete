using Doselete.Domain.Repository.Query;
using Doselete.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Doselete.Domain.Repository.Data
{
    public interface INodeData
    {
        public Task<List<NodeRoot>> GetRootAsync();
        public Task<List<NodeList>> GetNodesListAsync(int IdNodeRoot);
        public Task InsertNodeAsync(Node node);
        public Task UpdateNodeAsync(Node node);
        public Task DeleteNodeAsync(int IdNode);
        public Task DeleteNodesAsync(int[] IdNode);

    }
    public class NodeData : INodeData
    {
        private readonly IDbConnection _connection;
        public NodeData(IConfiguration configuration, IDbConnection connection)
        {
            _connection = connection;
            _connection.ConnectionString = configuration.GetConnectionString("dbSQL");
        }

        #region NodeRoot
        public async Task<List<NodeRoot>> GetRootAsync()
        {
            List<NodeRoot> result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<NodeRoot>(NodeQueries.GetNodeRoot)).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.GetRootAsync:", ex);
            }
            return result;
        }
        public async Task<List<NodeList>> GetNodesListAsync(int IdNodeRoot)
        {
            List<NodeList> result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<NodeList>(NodeQueries.GetNodesListByIdNodeRoot, new { IdNode = IdNodeRoot })).ToList();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.GetNodesListAsync:", ex);
            }
            return result;
        }
        public async Task InsertNodeAsync(Node node)
        {
            try
            {
                _connection.Open();
                node.Id = await _connection.ExecuteScalarAsync<int>(NodeQueries.InsertNode, node);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.InsertNodeAsync:", ex);
            }
        }

        public async Task UpdateNodeAsync(Node node)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeQueries.UpdateNode, node);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.UpdateNodeAsync:", ex);
            }
        }

        public async Task DeleteNodeAsync(int IdNode)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeQueries.DeleteNode, new { IdNode });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.DeleteNodeAsync:", ex);
            }
        }
        public async Task DeleteNodesAsync(int[] IdNodes)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(NodeQueries.DeleteNodes, new { IdNodes });
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD NodeData.DeleteNodeAsync:", ex);
            }
        }
        #endregion

        #region Node

        #endregion
    }
}
