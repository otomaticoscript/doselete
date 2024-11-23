using System.Data;
using Dapper;
using Doselete.Domain.Entity;
using Doselete.Domain.Repository.Query;
using Microsoft.Extensions.Configuration;

namespace Doselete.Domain.Repository.Data
{
    public interface IProductData<T> {
        public Task<T?> GetByIdProductAsync(int IdProduct);
        public Task InsertAsync(T data);
        /*
        public Task UpdateAsync(Master master);
        public Task DeleteAsync(int IdMaster);
        */
    }
    public class TvMazeData: IProductData<TvMazeProduct>
    {
        private readonly IDbConnection _connection;
        public TvMazeData(IConfiguration configuration, IDbConnection connection)
        {
            _connection = connection;
            _connection.ConnectionString = configuration.GetConnectionString("dbSQL");
        }
        public async Task<TvMazeProduct?> GetByIdProductAsync(int IdProduct)
        {
            TvMazeProduct? result;
            try
            {
                _connection.Open();
                result = (await _connection.QueryAsync<TvMazeProduct>(TVMazeQueries.GetByIdProduct,  new { Id = IdProduct })).FirstOrDefault();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TvMazeData.GetByIdProductAsync:", ex);
            }
            return result;
        }

        public async Task InsertAsync(TvMazeProduct data)
        {
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(TVMazeQueries.Insert, data);
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error BBDD TvMazeData.InsertAsync:", ex);
            }
        }
    }
}
