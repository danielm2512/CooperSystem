using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.GetAllProduto
{
    public interface IGetAllProdutoUseCase
    {
        Task<Result<List<PadariaResponse>>> Execute(string nome, string origem);
    }
}
