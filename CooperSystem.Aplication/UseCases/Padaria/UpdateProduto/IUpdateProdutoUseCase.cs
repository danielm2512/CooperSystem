using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.UpdateProduto
{
    public interface IUpdateProdutoUseCase
    {
        Task<Result<PadariaResponse>> Execute(PadariaUpdate produto);
    }
}
