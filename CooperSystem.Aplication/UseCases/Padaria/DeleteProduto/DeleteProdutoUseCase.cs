using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Padaria.DeleteProduto
{
    public class DeleteProdutoUseCase : IDeleteProdutoUseCase
    {
        private readonly IPadariaRepository _padariaRepository;

        public DeleteProdutoUseCase(IPadariaRepository padariaRepository)
        {
            _padariaRepository = padariaRepository;
        }

        public async Task<Result<string>> Execute(int id)
        {
            var result = new Result<string>();
            try
            {

                int RowsAffected = await _padariaRepository.Delete(id);

                if (RowsAffected == 0)
                {
                    result = new Result<string>
                    {
                        Sucess = false,
                        Message = "Nenhuma produto foi deletado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<string>
                    {
                        Sucess = true,
                        Message = "removido com sucesso",
                        Data = "Produto Deletado"
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<string>
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


