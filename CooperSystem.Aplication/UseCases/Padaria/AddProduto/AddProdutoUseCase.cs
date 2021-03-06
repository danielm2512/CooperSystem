using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Padaria;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.AddProduto
{
    public class AddProdutoUseCase : IAddProdutoUseCase
    {

        private readonly IPadariaRepository _padariaRepository;

        public AddProdutoUseCase(IPadariaRepository padariaRepository)
        {
            _padariaRepository = padariaRepository;
        }
        public async Task<Result<PadariaResponse>> Execute(PadariaRequest padaria)
        {
            var result = new Result<PadariaResponse>();
            try
            {

                var ProdutoAdicionado = await _padariaRepository.Add(padaria);

                if (ProdutoAdicionado == null )
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum carro foi adicionado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<PadariaResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = ProdutoAdicionado,
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
