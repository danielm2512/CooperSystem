using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.GetDetailProduto
{
    public class GetDetailProdutoUseCase : IGetDetailProdutoUseCase
    {
        private readonly IPadariaRepository _padariaRepository;

        public GetDetailProdutoUseCase(IPadariaRepository padariaRepository)
        {
            _padariaRepository = padariaRepository;
        }

        public async Task<Result<PadariaResponse>> Execute(int id)
        {
            var result = new Result<PadariaResponse>();
            try
            {

                var produto = await _padariaRepository.GetDetail(id);

                if (produto == null)
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum produto foi adicionado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = produto,
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

