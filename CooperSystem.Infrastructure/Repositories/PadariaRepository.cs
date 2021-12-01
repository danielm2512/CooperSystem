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
    }
}
