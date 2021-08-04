using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class GetCarrosResponseExample : IExamplesProvider<Result<CarroGet[]>>
    {
        public Result<CarroGet[]> GetExamples()
        {
            var valor = new OrigemResponse {Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };


            var carros = new CarroGet
            {
                Id = 1,
                Nome = "chevrolet chevelle malibu",
                Origem = valor,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            return new Result<CarroGet[]>
            {
                Data = new CarroGet[]
                {
                carros,
                carros,
                carros
                },
                Message = "Sucess",
                Total = 3,
                Sucess = true

            };
        }
    }
}
