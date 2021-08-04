using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class AddMarcaResponseExample : IExamplesProvider<Result<MarcaResponse>>
    {
        public Result<MarcaResponse> GetExamples()
        {
            var valor = new OrigemResponse {Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };


            return new Result<MarcaResponse>
            {
                Data = new MarcaResponse
                {
                Id = 1,
                Nome = "Volkswagen",
                Origem = valor,
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
