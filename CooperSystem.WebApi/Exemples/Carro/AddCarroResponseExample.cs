using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class AddFipeResponseExample : IExamplesProvider<Result<CarroResponse>>
    {
        public Result<CarroResponse> GetExamples()
        {
            var valor = new OrigemResponse {Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };

            return new Result<CarroResponse>
            {
                Data = new CarroResponse
                {
                Id = 1,
                Aceleracao = 12,
                Ano = DateTime.Now,
                Cavalor_de_forca = 130,
                Cilindros= 8,
                Km_por_galao = 18,
                Nome = "chevrolet chevelle malibu",
                Peso = 3504,
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
