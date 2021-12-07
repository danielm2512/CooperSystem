using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.UpdateProduto
{
    public class UpdateProdutoUseCase : IUpdateProdutoUseCase
    {
        private readonly IPadariaRepository _padariaRepository;

        public UpdateProdutoUseCase(IPadariaRepository padariaRepository)
        {
            _padariaRepository = padariaRepository;
        }

        public async Task<Result<PadariaResponse>> Execute(PadariaUpdate produto)
        {
            var result = new Result<PadariaResponse>();
            try
            {

                var produtoAtualizado = await _padariaRepository.Update(produto);

                if (produtoAtualizado == null)
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum produto foi atualizado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = produtoAtualizado,
                        Total = 1
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<PadariaResponse>
                {
                    Sucess = false,
                    Message = "Erro",
                    Data = null
                };
            }
            return result;
        }
    }

}

