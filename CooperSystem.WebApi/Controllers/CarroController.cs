using CooperSystem.Application.UseCases.Carro.AddCarro;
using CooperSystem.Application.UseCases.Carro.DeleteCarro;
using CooperSystem.Application.UseCases.Carro.GetAllCarro;
using CooperSystem.Application.UseCases.Carro.GetDatailCarro;
using CooperSystem.Application.UseCases.Carro.UpdateCarro;
using CooperSystem.Domain.Dto;
using CooperSystem.WebApi.Examples;
using CooperSystem.WebApi.Examples.Carro;
using CooperSystem.WebApi.Presenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.WebApi.Controllers
{
    /// <response code="400">Review information</response>
    /// <response code="500">Something wrong in code</response>

    [Route("api/[controller]")]
    [ApiController]

    [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<string>), StatusCodes.Status500InternalServerError)]
    public class CarroController : Controller
    {
        Presenters _Presenters;
        private readonly IAddCarroUseCase _addCarroUseCase;
        private readonly IDeleteCarroUseCase _deleteCarroUseCase;
        private readonly IGetAllCarroUseCase _getAllCarroUseCase;
        private readonly IGetDatailCarroUseCase _getDatailCarroUseCase;
        private readonly IUpdateCarroUseCase _updateCarroUseCase;

        public CarroController(Presenters Presenters,
            IAddCarroUseCase addCarroUseCase,
            IDeleteCarroUseCase deleteCarroUseCase,
            IGetAllCarroUseCase getAllCarroUseCase,
            IGetDatailCarroUseCase getDatailCarroUseCase,
            IUpdateCarroUseCase updateCarroUseCase
            )
        {
            _Presenters = Presenters;
            _addCarroUseCase = addCarroUseCase;
            _deleteCarroUseCase = deleteCarroUseCase;
            _getAllCarroUseCase = getAllCarroUseCase;
            _getDatailCarroUseCase = getDatailCarroUseCase;
            _updateCarroUseCase = updateCarroUseCase;
        }
        /// <summary>
        /// Adiciona Novo Carro
        /// </summary>
        /// <response code="200">Novo Carro Criado</response>
        [SwaggerRequestExample(typeof(CarroRequest), typeof(AddCarroRequestExample))]
        [HttpPost("AddCarro")]
        [ProducesResponseType(typeof(Result<CarroResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddCarroResponseExample))]
        public async Task<IActionResult> AddCarro(CarroRequest carro)
        {
            Result<CarroResponse> result = await _addCarroUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todo detalhamento do carro
        /// </summary>
        /// <response code="200">Carro verificado</response>
        [HttpGet("GetDetailsCarro")]
        [ProducesResponseType(typeof(Result<CarroResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddCarroResponseExample))]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<CarroResponse> result = await _getDatailCarroUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todos os carros, podendo filtar através do nome e da origem
        /// </summary>
        /// <response code="200">Carros verificados</response>
        [HttpGet("GetAllCarro")]
        [ProducesResponseType(typeof(Result<CarroGet>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(GetCarrosResponseExample))]
        public async Task<IActionResult> GetAll(string nome, string origem)
        {
            Result<List<CarroGet>> result = await _getAllCarroUseCase.Execute(nome, origem);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Atualiza Carro
        /// </summary>
        /// <response code="200">Carro Atualizado</response>
        [SwaggerRequestExample(typeof(CarroUpdate), typeof(UpdateCarrosRequestExample))]
        [HttpPut("UpdateCarro")]
        [ProducesResponseType(typeof(Result<CarroResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddCarroResponseExample))]
        public async Task<IActionResult> UpdateCarro(CarroUpdate carro)
        {
            Result<CarroResponse> result = await _updateCarroUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }


        /// <summary>
        /// Deleta Carro
        /// </summary>
        /// <response code="200">Carro Deletado</response>
        [HttpDelete("DeleteCarro")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(DeleteExample))]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            Result<string> result = await _deleteCarroUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }
}
