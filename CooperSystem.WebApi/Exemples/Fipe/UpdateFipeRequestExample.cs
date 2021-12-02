using CooperSystem.Domain.Dto.Fipe;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Exemples.Fipe
{
    public sealed class UpdateFipeRequestExample : IExamplesProvider<FipeUpdate>
    {
     public FipeUpdate GetExamples()
            {
                return new FipeUpdate
                {
                    Id = 1,
                    NomeCarro = "CarroTesteAtualizado",
                    Ano = DateTime.Now,
                    Valor = "2024",

                };
            }
        }
    }

