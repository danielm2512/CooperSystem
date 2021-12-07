using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.GetAllProduto
{
    public class GetAllProdutoUseCase : IGetAllProdutoUseCase
    {
        private readonly IPadariaRepository _padariaRepository;

        public GetAllProdutoUseCase(IPadariaRepository padariaRepository)
        {
            _padariaRepository = padariaRepository;
        }

        public async Task<Result<List<PadariaResponse>>> Execute(string nome, string origem)
        {
            var result = new Result<List<PadariaResponse>>();
            try
            {

                var produto = await _padariaRepository.GetAll(nome, origem);

                if (produto.Count == 0)
                {
                    result = new Result<List<PadariaResponse>>
                    {
                        Sucess = false,
                        Message = "Nenhum produto foi encontrado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<List<PadariaResponse>>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = produto
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<List<PadariaResponse>>
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
