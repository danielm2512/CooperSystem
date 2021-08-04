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
    public class CarroRepository : ICarroRepository
    {
        private readonly string connectionString;

        public CarroRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<CarroResponse> Add(CarroRequest carro)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertSql = @"INSERT INTO Carro (Nome, [Km_por_galao], Cilindros,[Cavalor_de_forca], Peso, Aceleracao, Ano,  OrigemId)
                                        VALUES (@Nome, @Km_por_galao, @Cilindros, @Cavalor_de_forca, @Peso, @Aceleracao, @Ano,  @OrigemId)
                                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Nome", carro.Nome);
                    Parameters.Add("@Km_por_galao", carro.Km_por_galao);
                    Parameters.Add("@Cilindros", carro.Cilindros);
                    Parameters.Add("@Cavalor_de_forca", carro.Cavalor_de_forca);
                    Parameters.Add("@Peso", carro.Peso);
                    Parameters.Add("@Aceleracao", carro.Aceleracao);
                    Parameters.Add("@Ano", carro.Ano);
                    Parameters.Add("@OrigemId", carro.OrigemId);

                    var id = db.QueryAsync<int>(insertSql, Parameters).Result.SingleOrDefault();

                    string selectSql = @"Select C.*, O.*  from Carro as C
                    inner join Origem as O on O.id = C.OrigemId
                    where C.Id = @Id";


                    var response = db.QueryAsync<CarroResponse>(selectSql,
                         new[]
                     {
                         typeof(CarroResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         CarroResponse carro = objects[0] as CarroResponse;
                         carro.Origem = (OrigemResponse)objects[1];


                         return carro;
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
                    string updateQuery = @"UPDATE[dbo].[Carro] SET  Enabled = @Enabled, UpdatedAt = @UpdatedAt WHERE Id = @Id";

                    int rowsAffected = await db.ExecuteAsync(updateQuery, new { Id = id , UpdatedAt = DateTime.Now , Enabled = false });

                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<CarroGet>> GetAll(string nome, string origem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectnome = nome != null ? " and C.Nome Like '%' + @Nome + '%' " : "";
                    string selectorigem = origem != null ? " and O.Abbr = @Abbr " : "";

                    string selectSql = @"Select * from Carro as C
                    inner join Origem as O on O.id = C.OrigemId
                    where Enabled = 1 " + selectnome + selectorigem;


                    var response = db.QueryAsync<CarroGet>(selectSql,
                         new[]
                     {
                         typeof(CarroGet),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         CarroGet carro = objects[0] as CarroGet;
                         carro.Origem = (OrigemResponse)objects[1];

                         return carro;
                     }, splitOn: "Id", param: new { Nome = nome, Abbr = origem }).Result.ToList();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CarroResponse> GetCarro(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string selectSql = @"Select * from Carro as C
                    inner join Origem as O on O.id = C.OrigemId
                    where C.Id = @Id and Enabled = 1";


                    var response = db.QueryAsync<CarroResponse>(selectSql,
                         new[]
                     {
                         typeof(CarroResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         CarroResponse carro = objects[0] as CarroResponse;
                         carro.Origem = (OrigemResponse)objects[1];

                         return carro;
                     }, splitOn: "Id", param: new { Id = id }).Result.SingleOrDefault();


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CarroResponse> Update(CarroUpdate carro)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE [Carro] SET  Nome = @Nome, [Km_por_galao] = @Km_por_galao, 
                     Cilindros = @Cilindros, [Cavalor_de_forca] = @Cavalor_de_forca, Peso = @Peso , Ano = @Ano, OrigemId = @OrigemId, UpdatedAt = @UpdatedAt
                     WHERE Id = @Id";

                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@Id", carro.Id);
                    Parameters.Add("@Nome", carro.Nome);
                    Parameters.Add("@Km_por_galao", carro.Km_por_galao);
                    Parameters.Add("@Cilindros", carro.Cilindros);
                    Parameters.Add("@Cavalor_de_forca", carro.Cavalor_de_forca);
                    Parameters.Add("@Peso", carro.Peso);
                    Parameters.Add("@Aceleracao", carro.Aceleracao);
                    Parameters.Add("@Ano", carro.Ano);
                    Parameters.Add("@OrigemId", carro.OrigemId);
                    Parameters.Add("@UpdatedAt", DateTime.Now);

                    db.QueryAsync<int>(updateQuery, Parameters).Result.SingleOrDefault();


                    string selectSql = @"Select C.*, O.*  from Carro as C
                    inner join Origem as O on O.id = C.OrigemId
                    where C.Id = @Id";


                    var response = db.QueryAsync<CarroResponse>(selectSql,
                         new[]
                     {
                         typeof(CarroResponse),
                         typeof(OrigemResponse),
                     },
                     objects =>
                     {

                         CarroResponse carro = objects[0] as CarroResponse;
                         carro.Origem = (OrigemResponse)objects[1];


                         return carro;
                     }, splitOn: "Id", param: new { Id = carro.Id }).Result.SingleOrDefault();



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
