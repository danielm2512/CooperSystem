using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Fipe
{
    public sealed class AddFipeRequestExample : IExamplesProvider<FipeRequest>
    {
       
        public FipeRequest GetExamples()
        {
            return new FipeRequest
            {
                //Id = 1,
                NomeCarro = "CarroTeste",
                Ano = DateTime.Now,
                Valor = "2012",
               // Enabled = true,
               // CreatedAt = DateTime.Now,
               // UpdatedAt = DateTime.Now 
                };
            }
    }
}
