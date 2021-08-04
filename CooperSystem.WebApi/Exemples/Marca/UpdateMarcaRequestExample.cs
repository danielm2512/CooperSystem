using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace CooperSystem.WebApi.Examples.Carro
{
    public sealed class UpdateMarcaRequestExample : IExamplesProvider<MarcaUpdate>
    {
        public MarcaUpdate GetExamples()
        {
            return new MarcaUpdate
            {
                Id = 1,
                Nome = "Volkswagen",
                OrigemId = 1,
            };
        }
    }
}
