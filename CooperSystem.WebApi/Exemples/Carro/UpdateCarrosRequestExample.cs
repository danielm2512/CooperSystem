using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class UpdateCarrosRequestExample : IExamplesProvider<CarroUpdate>
    {
        public CarroUpdate GetExamples()
        {
            return new CarroUpdate
            {
                Id = 1,
                Aceleracao = 12,
                Ano = DateTime.Now,
                Cavalor_de_forca = 130,
                Cilindros = 8,
                Km_por_galao = 18,
                Nome = "chevrolet chevelle malibu",
                Peso = 3504,
                OrigemId = 1,

            };
        }
    }
}
