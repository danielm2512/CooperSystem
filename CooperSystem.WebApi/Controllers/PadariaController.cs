using CooperSystem.Application.UseCases.Padaria.AddProduto;
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

        private readonly IAddProdutoUseCase _addProdutoUseCase;

        Presenters _Presenters;
        public PadariaController(Presenters Presenters, IAddProdutoUseCase addProdutoUseCase)
        {
            _Presenters = Presenters;
            _addProdutoUseCase = addProdutoUseCase;
        }

        [HttpPost("AddProduto")]
        public async Task<IActionResult> AddProduto(PadariaRequest produto)
        {
            Result<PadariaResponse> result = await _addProdutoUseCase.Execute(produto);
            _Presenters.Populate(result);
            return _Presenters.ContentResult;
        }
    }
}
