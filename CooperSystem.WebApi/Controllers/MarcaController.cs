using CooperSystem.Application.UseCases.Marca.AddMarca;
using CooperSystem.Application.UseCases.Marca.DeleteMarca;
using CooperSystem.Application.UseCases.Marca.GetAllMarca;
using CooperSystem.Application.UseCases.Marca.GetDetailMarca;
using CooperSystem.Application.UseCases.Marca.UpdateMarca;
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
    public class MarcaController : Controller
    {
        Presenters _Presenters;
        private readonly IAddMarcaUseCase _addMarcaUseCase;
        private readonly IDeleteMarcaUseCase _deleteMarcaUseCase;
        private readonly IGetAllMarcaUseCase _getAllMarcaUseCase;
        private readonly IGetDetailMarcaUseCase _getDetailMarcaUseCase;
        private readonly IUpdateMarcaUseCase _updateMarcaUseCase;

        public MarcaController(Presenters Presenters,
        IAddMarcaUseCase addMarcaUseCase,
        IDeleteMarcaUseCase deleteMarcaUseCase,
        IGetAllMarcaUseCase getAllMarcaUseCase,
        IGetDetailMarcaUseCase getDetailMarcaUseCase,
        IUpdateMarcaUseCase updateMarcaUseCase)
        {
            _Presenters = Presenters;
            _addMarcaUseCase = addMarcaUseCase;
            _deleteMarcaUseCase = deleteMarcaUseCase;
            _getAllMarcaUseCase = getAllMarcaUseCase;
            _getDetailMarcaUseCase = getDetailMarcaUseCase;
            _updateMarcaUseCase = updateMarcaUseCase;
        }
        /// <summary>
        /// Adiciona Nova Marca
        /// </summary>
        /// <response code="200">Nova Marca adicionada</response>
        [SwaggerRequestExample(typeof(MarcaRequest), typeof(AddMarcaRequestExample))]
        [HttpPost("AddMarca")]
        [ProducesResponseType(typeof(Result<MarcaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddMarcaResponseExample))]
        public async Task<IActionResult> AddMarca(MarcaRequest carro)
        {
            Result<MarcaResponse> result = await _addMarcaUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todo detalhamento da marca
        /// </summary>
        /// <response code="200">Marca verificada</response>
        [HttpGet("GetDetailsMarca")]
        [ProducesResponseType(typeof(Result<MarcaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddMarcaResponseExample))]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<MarcaResponse> result = await _getDetailMarcaUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Verifica todas as marcas, podendo filtar através do nome e da origem
        /// </summary>
        /// <response code="200">Marcas verificadas</response>
        [HttpGet("GetAllMarca")]
        [ProducesResponseType(typeof(Result<MarcaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(GetMarcaResponseExample))]
        public async Task<IActionResult> GetAll(string nome, string origem)
        {
            Result<List<MarcaResponse>> result = await _getAllMarcaUseCase.Execute(nome, origem);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

        /// <summary>
        /// Atualiza Marca
        /// </summary>
        /// <response code="200">Marca Atualizada</response>
        [SwaggerRequestExample(typeof(MarcaUpdate), typeof(UpdateMarcaRequestExample))]
        [HttpPut("UpdateMarca")]
        [ProducesResponseType(typeof(Result<MarcaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddMarcaResponseExample))]
        public async Task<IActionResult> UpdateMarca(MarcaUpdate carro)
        {
            Result<MarcaResponse> result = await _updateMarcaUseCase.Execute(carro);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }


        /// <summary>
        /// Deleta Marca
        /// </summary>
        /// <response code="200">Marca Deletada</response>
        [HttpDelete("DeleteMarca")]
        [ProducesResponseType(typeof(Result<MarcaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddMarcaResponseExample))]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(DeleteExample))]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            Result<string> result = await _deleteMarcaUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }
}
