using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class GetMarcaResponseExample : IExamplesProvider<Result<MarcaResponse[]>>
    {
        public Result<MarcaResponse[]> GetExamples()
        {
            var valor = new OrigemResponse {Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };


            var marca = new MarcaResponse
            {
                Id = 1,
                Nome = "chevrolet chevelle malibu",
                Origem = valor,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            return new Result<MarcaResponse[]>
            {
                Data = new MarcaResponse[]
                {
                marca,
                marca,
                marca
                },
                Message = "Sucess",
                Total = 3,
                Sucess = true

            };
        }
    }
}
