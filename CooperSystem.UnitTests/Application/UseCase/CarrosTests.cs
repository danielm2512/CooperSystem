using CooperSystem.Application.UseCases.Carro.AddCarro;
using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using CooperSystem.WebApi.Examples.Carro;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CooperSystem.UnitTests.Application.UseCase
{

    public class CarroTests 
    {
        [Fact]
        public void AddCarro_Execute_ReturnCarro()
        {
            // Arrange
            var CarroRepositoryMock = new Mock<ICarroRepository>();
            var valor = new OrigemResponse { Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            var carroRequest = new CarroRequest
            {
                Aceleracao = 12,
                Ano = DateTime.Now,
                Cavalor_de_forca = 130,
                Cilindros = 8,
                Km_por_galao = 18,
                Nome = "chevrolet chevelle malibu",
                Peso = 3504,
                OrigemId = 1,
            };

            var carroResponse = new CarroResponse
            {
                Id = 1,
                Aceleracao = 12,
                Ano = DateTime.Now,
                Cavalor_de_forca = 130,
                Cilindros = 8,
                Km_por_galao = 18,
                Nome = "chevrolet chevelle malibu",
                Peso = 3504,
                Origem = valor,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            CarroRepositoryMock.Setup(x => x.Add(carroRequest).Result).Returns(carroResponse);


            var createProjectCommandHandler = new AddCarroUseCase(CarroRepositoryMock.Object);

            // Act
            var result = createProjectCommandHandler.Execute(carroRequest).Result;

            // Assert

            CarroRepositoryMock.Verify(pr => pr.Add(It.IsAny<CarroRequest>()), Times.Once);
            Assert.NotNull(result.Data);
            Assert.Equal(true, result.Sucess);
        }

    }
}
