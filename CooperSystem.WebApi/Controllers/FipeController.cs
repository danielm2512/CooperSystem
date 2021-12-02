using CooperSystem.Application.UseCases.Fipe.AddFipe;
using CooperSystem.Application.UseCases.Fipe.DeleteFipe;
using CooperSystem.Application.UseCases.Fipe.GetAllFipe;
using CooperSystem.Application.UseCases.Fipe.GetDetailFipe;
using CooperSystem.Application.UseCases.Fipe.UpdateFipe;
using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using CooperSystem.WebApi.Examples;
using CooperSystem.WebApi.Examples.Fipe;
using CooperSystem.WebApi.Exemples.Fipe;
using CooperSystem.WebApi.Presenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CooperSystem.WebApi.Controllers
{
    /// <response code="400">Review information</response>
    /// <response code="500">Something wrong in code</response>

    [Route("api/[controller]")]
    [ApiController]

    [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result<string>), StatusCodes.Status500InternalServerError)]
    public class FipeController : Controller
    {
        Presenters _Presenters;
        private readonly IAddFipeUseCase _addFipeUseCase;
        private readonly IDeleteFipeUseCase _deleteFipeUseCase;
        private readonly IUpdateFipeUseCase _updateFipeUseCase;
        private readonly IGetAllFipeUseCase _getAllFipeUseCase;
        private readonly IGetDetailFipeUseCase _getDetailFipeUseCase;


        public FipeController(Presenters Presenters,
            IAddFipeUseCase addFipeUseCase,
            IDeleteFipeUseCase deleteFipeUseCase,
            IUpdateFipeUseCase updateFipeUseCase,
            IGetAllFipeUseCase getAllFipeUseCase,
            IGetDetailFipeUseCase getDetailFipeUseCase
            )
        {
            _Presenters = Presenters;
            _addFipeUseCase = addFipeUseCase;
            _deleteFipeUseCase = deleteFipeUseCase;
            _updateFipeUseCase = updateFipeUseCase;
            _getAllFipeUseCase = getAllFipeUseCase;
            _getDetailFipeUseCase = getDetailFipeUseCase;

        }
        /// <summary>
        /// Adiciona Novo Fipe
        /// </summary>
        /// <response code="200">Novo Fipe Criado</response>
        [SwaggerRequestExample(typeof(FipeRequest), typeof(AddFipeRequestExample))]
        [HttpPost("AddFipe")]
        [ProducesResponseType(typeof(Result<FipeResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddFipeResponseExample))]
        public async Task<IActionResult> AddFipe(FipeRequest fipe)
        {
            Result<FipeResponse> result = await _addFipeUseCase.Execute(fipe);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Verifica detalhe de um registro fipe
        /// </summary>
        /// <response code="200">Fipe verificado</response>
        [HttpGet("GetDetailsFipe")]
        [ProducesResponseType(typeof(Result<FipeResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddFipeResponseExample))]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<FipeResponse> result = await _getDetailFipeUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Verifica todos os registro de fipe, podendo filtar através do nome e o ano
        /// </summary>
        /// <response code="200">Fipes verificados</response>
        [HttpGet("GetAllFipe")]
        [ProducesResponseType(typeof(Result<FipeResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(GetFipesResponseExample))]
        public async Task<IActionResult> GetAll(string nome, string ano)
        {
            Result<List<FipeResponse>> result = await _getAllFipeUseCase.Execute(nome, ano);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Atualiza Fipe
        /// </summary>
        /// <response code="200">Fipe Atualizado</response>
        [SwaggerRequestExample(typeof(FipeUpdate), typeof(UpdateFipeRequestExample))]
        [HttpPut("UpdateFipe")]
        [ProducesResponseType(typeof(Result<FipeResponse>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(AddFipeResponseExample))]
        public async Task<IActionResult> UpdateCarro(FipeUpdate fipe)
        {
            Result<FipeResponse> result = await _updateFipeUseCase.Execute(fipe);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }


        /// <summary>
        /// Deleta Fipe
        /// </summary>
        /// <response code="200">Fipe Deletado</response>
        [HttpDelete("DeleteFipe")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(200, typeof(DeleteExample))]
        public async Task<IActionResult> DeleteFipe(int id)
        {
            Result<string> result = await _deleteFipeUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }



}
