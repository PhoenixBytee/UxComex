using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;

namespace UxComex.Source.Infraestructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAsync()
        {
            using IDbConnection db = CreateConnection();
            string query = "SELECT * FROM Address";
            return await db.QueryAsync<AddressEntity>(query);
        }

        public async Task<IEnumerable<AddressEntity>> GetByClientIdAsync(int clientId)
        {
            using IDbConnection db = CreateConnection();
            string query = "SELECT * FROM Address WHERE ClientId = @ClientId";
            return await db.QueryAsync<AddressEntity>(query, new { ClientId = clientId });
        }

        public async Task<AddressEntity> GetByIdAsync(int id)
        {
            using IDbConnection db = CreateConnection();
            string query = "SELECT * FROM Address WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<AddressEntity>(query, new { Id = id });
        }

        public async Task<int> InsertAsync(AddressEntity entity)
        {
            using IDbConnection db = CreateConnection();
            string query = @"
                INSERT INTO 
                Address (Address, Cep, City, State, ClientId) 
                VALUES (@Address, @Cep, @City, @State, @ClientId); 
                SELECT SCOPE_IDENTITY();";
            return await db.ExecuteScalarAsync<int>(query, entity);
        }

        public async Task<int> UpdateAsync(AddressEntity entity)
        {
            using IDbConnection db = CreateConnection();
            string query = @"
                UPDATE 
                Address SET 
                Address = @Address, 
                Cep = @Cep, 
                City = @City, 
                State = @State, 
                ClientId = @ClientId
                WHERE Id = @Id";
            return await db.ExecuteAsync(query, entity);
        }
        public async Task<int> DeleteAsync(int id)
        {
            using IDbConnection db = CreateConnection();
            string query = "DELETE FROM Address WHERE Id = @Id";
            return await db.ExecuteAsync(query, new { Id = id });
        }
    }
}
