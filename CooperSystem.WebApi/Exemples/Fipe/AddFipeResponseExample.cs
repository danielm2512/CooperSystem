using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Fipe
{
    public sealed class AddFipeResponseExample : IExamplesProvider<Result<FipeResponse>>
    {
   
        public Result<FipeResponse> GetExamples()
        {
            return new Result<FipeResponse>
            {
                Data = new FipeResponse
                {
                    Id = 1,
                    NomeCarro = "CarroTeste",
                    Ano = DateTime.Now,
                    Valor = "2012",
                    Enabled = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                Message = "Sucess",
                Sucess = true
            };
        }
    }
}
