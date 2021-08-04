using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.Infrastructure.Data.Repositories
{
    public class MarcaRpository : IMarcaRepository
    {
        private readonly string connectionString;

        public MarcaRpository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<MarcaResponse> Add(MarcaRequest marca)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"INSERT INTO Marca (Nome, OrigemId )
                                        VALUES (@Nome, @OrigemId)
                                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Nome", marca.Nome);
                    Parameters.Add("@OrigemId", marca.OrigemId);

                    var id = db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select M.*, O.* from Marca as M
                    inner join Origem as O on O.id = M.OrigemId
                    where M.Id = @Id";


                    var response =  db.QueryAsync<MarcaResponse>(selectSql,
                         new[]
                     {
                         typeof(MarcaResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         MarcaResponse marca = objects[0] as MarcaResponse;
                         marca.Origem = (OrigemResponse)objects[1];


                         return marca;
                     }, splitOn: "Id", param: new {Id = id }).Result.SingleOrDefault();


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
                    string updateQuery = @"UPDATE[dbo].[Marca] SET  Enabled = @Enabled, UpdatedAt = @UpdatedAt  WHERE Id = @Id";

                    int rowsAffected = await db.ExecuteAsync(updateQuery, new {Id = id , Enabled = false, UpdatedAt = DateTime.Now });

                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<MarcaResponse>> GetAll(string nome, string origem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectnome = nome != null ? " and M.Nome Like '%' + @Nome + '%' " : "";
                    string selectorigem = origem != null ? " and O.Abbr = @Abbr " : "";

                    string selectSql = @"Select M.*, O.* from Marca as M
                    inner join Origem as O on O.id = M.OrigemId where Enabled = 1" +  selectnome + selectorigem;


                    var response = db.Query<MarcaResponse>(selectSql,
                         new[]
                     {
                         typeof(MarcaResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         MarcaResponse marca = objects[0] as MarcaResponse;
                         marca.Origem = (OrigemResponse)objects[1];

                         return marca;
                     }, splitOn: "Id", param: new { Nome = nome, Abbr = origem}).ToList();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MarcaResponse> GetDetail(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectSql = @"Select M.*, O.* from Marca as M
                    inner join Origem as O on O.id = M.OrigemId
                    where M.Id = @Id and Enabled = 1";


                    var response = db.QueryAsync<MarcaResponse>(selectSql,
                         new[]
                     {
                         typeof(MarcaResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         MarcaResponse marca = objects[0] as MarcaResponse;
                         marca.Origem = (OrigemResponse)objects[1];

                         return marca;
                     }, splitOn: "Id", param: new { Id = id }).Result.SingleOrDefault();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MarcaResponse> Update(MarcaUpdate marca)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"Update Marca SET  Nome = @Nome, OrigemId = @OrigemId, UpdatedAt = @UpdatedAt
                     WHERE Id = @Id";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Id", marca.Id);
                    Parameters.Add("@Nome", marca.Nome);
                    Parameters.Add("@OrigemId", marca.OrigemId);
                    Parameters.Add("@UpdatedAt", DateTime.Now);

                    db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select M.*, O.* from Marca as M
                    inner join Origem as O on O.id = M.OrigemId
                    where M.Id = @Id";


                    var response = db.QueryAsync<MarcaResponse>(selectSql,
                         new[]
                     {
                         typeof(MarcaResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         MarcaResponse marca = objects[0] as MarcaResponse;
                         marca.Origem = (OrigemResponse)objects[1];


                         return marca;
                     }, splitOn: "Id", param: new { Id = marca.Id }).Result.SingleOrDefault();


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
