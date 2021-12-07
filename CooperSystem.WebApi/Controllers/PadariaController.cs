using CooperSystem.Application.UseCases.Padaria.AddProduto;
using CooperSystem.Application.UseCases.Padaria.DeleteProduto;
using CooperSystem.Application.UseCases.Padaria.GetAllProduto;
using CooperSystem.Application.UseCases.Padaria.GetDetailProduto;
using CooperSystem.Application.UseCases.Padaria.UpdateProduto;
using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.WebApi.Presenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PadariaController : ControllerBase
    {

        Presenters _Presenters;
        private readonly IAddProdutoUseCase _addProdutoUseCase;
        private readonly IDeleteProdutoUseCase _deleteProdutoUseCase;
        private readonly IGetAllProdutoUseCase _getAllProdutoUseCase;
        private readonly IUpdateProdutoUseCase _updateProdutoUseCase;
        private readonly IGetDetailProdutoUseCase _getDetailProdutoUseCase;

        public PadariaController(Presenters Presenters, 
            IAddProdutoUseCase addProdutoUseCase, 
            IDeleteProdutoUseCase deleteProdutoUseCase, 
            IGetAllProdutoUseCase getAllProdutoUseCase,
            IUpdateProdutoUseCase updateProdutoUseCase,
            IGetDetailProdutoUseCase getDetailProdutoUseCase)
        {
            _Presenters = Presenters;
            _addProdutoUseCase = addProdutoUseCase;
            _deleteProdutoUseCase = deleteProdutoUseCase;
            _getAllProdutoUseCase = getAllProdutoUseCase;
            _updateProdutoUseCase = updateProdutoUseCase;
            _getDetailProdutoUseCase = getDetailProdutoUseCase;

        }
        /// <summary>
        /// Adiciona Novo Produto
        /// </summary>
        /// <response code="200">Novo Produto adicionado</response>
        [HttpPost("AddProduto")]
        public async Task<IActionResult> AddProduto(PadariaRequest produto)
        {
            Result<PadariaResponse> result = await _addProdutoUseCase.Execute(produto);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Deleta o Produto
        /// </summary>
        /// <response code="200">Produto deletado</response>
        [HttpDelete("DeleteProduto")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            Result<string> result = await _deleteProdutoUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Verifica todos os produtos, podendo filtar através do nome e da origem
        /// </summary>
        /// <response code="200">Produtos verificados</response>
        [HttpGet("GetAllProduto")]
        public async Task<IActionResult> GetAll(string nome, string origem)
        {
            Result<List<PadariaResponse>> result = await _getAllProdutoUseCase.Execute(nome, origem);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Atualizo o Produto
        /// </summary>
        /// <response code="200">Produto Atualizado</response>
        [HttpPut("UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(PadariaUpdate produto)
        {
            Result<PadariaResponse> result = await _updateProdutoUseCase.Execute(produto);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
        /// <summary>
        /// Verifica todo detalhamento do produto
        /// </summary>
        /// <response code="200">Produto verificado</response>
        [HttpGet("GetDetailsProduto")]
        public async Task<IActionResult> GetDetails(int id)
        {
            Result<PadariaResponse> result = await _getDetailProdutoUseCase.Execute(id);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }

    }
}
