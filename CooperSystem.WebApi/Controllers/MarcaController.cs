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
    public class MarcaController : Controller
    {
        Presenters _Presenters;

        public MarcaController(Presenters Presenters)
        {
            _Presenters = Presenters;
        }
        /// <summary>
        /// Adiciona Nova Marca
        /// </summary>
        /// <response code="200">Nova Marca adicionada</response>
        [HttpPost("AddCarro")]
        public async Task<IActionResult> AddMarca(MarcaRequest carro)
        {
            Result<CarroResponse> result = await _AddMarcaUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todo detalhamento da marca
        /// </summary>
        /// <response code="200">Marca verificada</response>
        [HttpGet("GetDetailsCarro")]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<CarroResponse> result = await _GetDetailMarcaUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todas as marcas, podendo filtar através do nome e da origem
        /// </summary>
        /// <response code="200">Marcas verificadas</response>
        [HttpGet("GetDetailsCarro")]
        public async Task<IActionResult> GetDetails(string nome, string origem)
        {
            Result<List<CarroGet>> result = await _GetAllMarcaUseCase.Execute(nome, origem);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Atualiza Marca
        /// </summary>
        /// <response code="200">Marca Atualizada</response>
        [HttpPut("UpdateCarro")]
        public async Task<IActionResult> UpdateCarro(CarroUpdate carro)
        {
            Result<CarroResponse> result = await _UpdateMarcaUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }


        /// <summary>
        /// Deleta Marca
        /// </summary>
        /// <response code="200">Marca Deletada</response>
        [HttpDelete("DeleteCarro")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            Result<string> result = await _DeleteMarcaUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }
}
