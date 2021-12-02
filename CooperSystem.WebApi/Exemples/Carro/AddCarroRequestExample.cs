using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class AddFipeRequestExample : IExamplesProvider<CarroRequest>
    {
        public CarroRequest GetExamples()
        {
            return new CarroRequest
            {
                Aceleracao = 12,
                Ano = DateTime.Now,
                Cavalor_de_forca = 130,
                Cilindros= 8,
                Km_por_galao = 18,
                Nome = "chevrolet chevelle malibu",
                Peso = 3504,
                OrigemId = 1,
            };
        }
    }
}
