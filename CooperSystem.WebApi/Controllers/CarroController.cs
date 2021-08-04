using CooperSystem.Domain.Dto;
using CooperSystem.WebApi.Presenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public CarroController(Presenters Presenters)
        {
            _Presenters = Presenters;
        }
        /// <summary>
        /// Adiciona Novo Carro
        /// </summary>
        /// <response code="200">Novo Carro Criado</response>
        [HttpPost("AddCarro")]
        public async Task<IActionResult> AddCarro(CarroRequest carro)
        {
            Result<CarroResponse> result = await _AddCarroUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todo detalhamento do carro
        /// </summary>
        /// <response code="200">Carro verificado</response>
        [HttpGet("GetDetailsCarro")]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<CarroResponse> result = await _GetDetailCarroUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todos os carros, podendo filtar através do nome e da origem
        /// </summary>
        /// <response code="200">Carros verificados</response>
        [HttpGet("GetDetailsCarro")]
        public async Task<IActionResult> GetDetails(string nome, string origem)
        {
            Result<List<CarroGet>> result = await _GetAllCarroUseCase.Execute(nome, origem);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Atualiza Carro
        /// </summary>
        /// <response code="200">Carro Atualizado</response>
        [HttpPut("UpdateCarro")]
        public async Task<IActionResult> UpdateCarro(CarroUpdate carro)
        {
            Result<CarroResponse> result = await _UpdateCarroUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }


        /// <summary>
        /// Deleta Carro
        /// </summary>
        /// <response code="200">Carro Deletado</response>
        [HttpDelete("DeleteCarro")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            Result<string> result = await _DeleteCarroUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }
}
