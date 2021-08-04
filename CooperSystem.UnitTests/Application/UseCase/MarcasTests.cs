using CooperSystem.Application.UseCases.Marca.AddMarca;
using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using Moq;
using System;
using Xunit;

namespace CooperSystem.UnitTests.Application.UseCase
{

    public class MarcasTests
    {
        [Fact]
        public void AddMarca_Execute_ReturnMarca()
        {
            // Arrange
            var marcaRepositoryMock = new Mock<IMarcaRepository>();
            var valor = new OrigemResponse { Id = 1, Abbr = "USA", Country = "Estados Unidos", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            var marcaRequest = new MarcaRequest
            {
                Nome = "Volkswagen",
                OrigemId = 1,
            };

            var marcaResponse = new MarcaResponse
            {
                Id = 1,
                Nome = "Volkswagen",
                Origem = valor,
                Enabled = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            marcaRepositoryMock.Setup(x => x.Add(marcaRequest).Result).Returns(marcaResponse);


            var createProjectCommandHandler = new AddMarcaUseCase(marcaRepositoryMock.Object);

            // Act
            var result = createProjectCommandHandler.Execute(marcaRequest).Result;

            // Assert

            marcaRepositoryMock.Verify(pr => pr.Add(It.IsAny<MarcaRequest>()), Times.Once);
            Assert.NotNull(result.Data);
            Assert.Equal(true, result.Sucess);
        }
    }
}
