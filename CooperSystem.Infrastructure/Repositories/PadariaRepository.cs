using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.Domain.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Infrastructure.Repositories
{
    public class PadariaRepository : IPadariaRepository
    {
        private readonly string connectionString;

        public PadariaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<PadariaResponse> Add(PadariaRequest padaria)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"INSERT INTO Padaria (Valor, Estoque, Nome)
                                        VALUES (@Valor, @Estoque, @Nome)
                                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Valor", padaria.Valor);
                    Parameters.Add("@Estoque", padaria.Estoque);
                    Parameters.Add("@Nome", padaria.Nome);

                    var id = db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select * from Padaria
                    where Id = @Id";

                    var response = db.QueryAsync<PadariaResponse>(selectSql, new { Id = id }).Result.SingleOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE[dbo].[Padaria] SET  Enabled = @Enabled, UpdatedAt = @UpdatedAt  WHERE Id = @Id";

                    int rowsAffected = await db.ExecuteAsync(updateQuery, new { Id = id, Enabled = false, UpdatedAt = DateTime.Now });

                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<PadariaResponse>> GetAll(string nome, string origem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectnome = nome != null ? " and P.Nome Like '%' + @Nome + '%' " : "";

                    string selectSql = @"Select * from Padaria as P
                    where Enabled = 1" + selectnome ;


                    var response = db.Query<PadariaResponse>(selectSql,
                         new[]
                     {
                         typeof(PadariaResponse),
                     },
                     objects =>
                     {

                         PadariaResponse produto = objects[0] as PadariaResponse;

                         return produto;
                     }, splitOn: "Id", param: new { Nome = nome, Abbr = origem }).ToList();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<PadariaResponse> Update(PadariaUpdate produto)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"Update Padaria SET  Nome = @Nome, UpdatedAt = @UpdatedAt
                     WHERE Id = @Id";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Id", produto.Id);
                    Parameters.Add("@Nome", produto.Nome);
                    Parameters.Add("@UpdatedAt", DateTime.Now);

                    db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select * from Padaria as P
                    where P.Id = @Id";


                    var response = db.QueryAsync<PadariaResponse>(selectSql,
                         new[]
                     {
                         typeof(PadariaResponse),
                     },
                     objects =>
                     {

                         PadariaResponse produto = objects[0] as PadariaResponse;

                         return produto;
                     }, splitOn: "Id", param: new { Id = produto.Id }).Result.SingleOrDefault();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<PadariaResponse> GetDetail(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectSql = @"Select * from Padaria as P
                    where P.Id = @Id and P.Enabled = 1";


                    var response = db.QueryAsync<PadariaResponse>(selectSql,
                         new[]
                     {
                         typeof(PadariaResponse),
                     },
                     objects =>
                     {

                         PadariaResponse produto = objects[0] as PadariaResponse;

                         return produto;
                     }, splitOn: "Id", param: new { Id = id }).Result.SingleOrDefault();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}

    

