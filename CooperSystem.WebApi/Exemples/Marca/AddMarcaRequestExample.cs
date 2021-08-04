using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class AddMarcaRequestExample : IExamplesProvider<MarcaRequest>
    {
        public MarcaRequest GetExamples()
        {
            return new MarcaRequest
            {
                Nome = "Volkswagen",
                OrigemId = 1,
            };
        }
    }
}
