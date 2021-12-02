using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
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
    public class FipeRepository : IFipeRepository
    {
        private readonly string connectionString;

        public FipeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //OK
        public async Task<FipeResponse> Add(FipeRequest fipe)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"INSERT INTO Fipe (NomeCarro, Ano,Valor  )
                                        VALUES (@NomeCarro, @Ano, @Valor)
                                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@NomeCarro", fipe.NomeCarro);
                    Parameters.Add("@Ano", fipe.Ano);
                    Parameters.Add("@Valor", fipe.Valor);

                    var id = db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select F.* from Fipe as F
                    where F.Id = @Id";


                    var response = db.QueryAsync<FipeResponse>(selectSql,
                         new[]
                     {
                         typeof(FipeResponse),
                     },
                     objects =>
                     {

                         FipeResponse fipe = objects[0] as FipeResponse;


                         return fipe;
                     }, splitOn: "Id", param: new { Id = id }).Result.SingleOrDefault();


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
                    string updateQuery = @"UPDATE[dbo].[Fipe] SET  Enabled = @Enabled, UpdatedAt = @UpdatedAt  WHERE Id = @Id";

                    int rowsAffected = await db.ExecuteAsync(updateQuery, new { Id = id, Enabled = false, UpdatedAt = DateTime.Now });

                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //OK
        public async Task<List<FipeResponse>> GetAll(string nome,string ano)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectnome = nome != null ? " and F.NomeCarro Like '%' + @Nome + '%' " : "";
                    string selectano = ano != null ? " and F.Ano Like '%' + @Ano + '%' " : "";

                    string selectSql = @"Select F.* from Fipe as F
                     where Enabled = 1" + selectnome + selectano;


                    var response = db.Query<FipeResponse>(selectSql,
                         new[]
                     {
                         typeof(FipeResponse),
                     },
                     objects =>
                     {

                         FipeResponse fipe = objects[0] as FipeResponse;

                         return fipe;
                     }, splitOn: "Id", param: new { Nome = nome }).ToList();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //OK
        public async Task<FipeResponse> GetFipe(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectSql = @"Select F.* from Fipe as F
                    where F.Id = @Id and Enabled = 1";


                    var response = db.QueryAsync<FipeResponse>(selectSql,
                         new[]
                     {
                         typeof(FipeResponse),
                     },
                     objects =>
                     {

                         FipeResponse fipe = objects[0] as FipeResponse;

                         return fipe;
                     }, splitOn: "Id", param: new { Id = id }).Result.SingleOrDefault();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //OK
        public async Task<FipeResponse> Update(FipeUpdate fipe)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"Update Fipe SET  NomeCarro = @NomeCarro, Ano = @Ano, Valor = @Valor ,UpdatedAt = @UpdatedAt
                     WHERE Id = @Id";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Id", fipe.Id);
                    Parameters.Add("@NomeCarro", fipe.NomeCarro);
                    Parameters.Add("@Ano", fipe.Ano);
                    Parameters.Add("@Valor", fipe.Valor);
                    Parameters.Add("@UpdatedAt", DateTime.Now);

                    db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select F.* from Fipe as F
                     where F.Id = @Id";


                    var response = db.QueryAsync<FipeResponse>(selectSql,
                         new[]
                     {
                         typeof(FipeResponse),
                     },
                     objects =>
                     {

                         FipeResponse fipe = objects[0] as FipeResponse;


                         return fipe;
                     }, splitOn: "Id", param: new { Id = fipe.Id }).Result.SingleOrDefault();


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
