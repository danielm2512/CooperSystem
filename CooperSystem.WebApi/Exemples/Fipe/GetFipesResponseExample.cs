using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Exemples.Fipe
{
    public sealed class GetFipesResponseExample : IExamplesProvider<Result<FipeGet[]>>
    {
            public Result<FipeGet[]> GetExamples()
            {
                var ano = "2021";


                var fipes = new FipeGet
                {
                    Id = 1,
                    NomeCarro = "chevrolet chevelle malibu",
                    Ano = DateTime.Now,
                    Valor = "2024",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };


                return new Result<FipeGet[]>
                {
                    Data = new FipeGet[]
                    {
                fipes,
                fipes,
                fipes
                    },
                    Message = "Sucess",
                    Total = 3,
                    Sucess = true

                };
            }
        }
    }

