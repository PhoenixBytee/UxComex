using System.Data.SqlClient;
using System.Data;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;
using Dapper;

namespace UxComex.Source.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<ClientEntity>> GetAllAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Client";
            return await db.QueryAsync<ClientEntity>(query);
        }

        public async Task<ClientEntity> GetByIdAsync(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Client WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<ClientEntity>(query, new { Id = id });
        }

        public async Task<int> InsertAsync(ClientEntity entity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"
                INSERT INTO 
                    Client (Name, Telephone, Cpf) 
                    VALUES (@Name, @Telephone, @Cpf); 
                    SELECT CAST(SCOPE_IDENTITY() as int)";
            int id = await db.QueryFirstOrDefaultAsync<int>(query, entity);
            return id;
        }

        public async Task<int> UpdateAsync(ClientEntity entity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"
                UPDATE 
                    Client SET 
                    Name = @Name, 
                    Telephone = @Telephone, 
                    Cpf = @Cpf,
                    UpdatedAt = @UpdatedAt 
                    WHERE Id = @Id";
            return await db.ExecuteAsync(query, entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "DELETE FROM Client WHERE Id = @Id";
            return await db.ExecuteAsync(query, new { Id = id });
        }
    }
}
