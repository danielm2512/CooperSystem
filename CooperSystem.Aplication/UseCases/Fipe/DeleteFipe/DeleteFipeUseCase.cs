using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.DeleteFipe
{
    public class DeleteFipeUseCase : IDeleteFipeUseCase
    {

        private readonly IFipeRepository _fipeRepository;

        public DeleteFipeUseCase(IFipeRepository fipeRepository)
        {
            _fipeRepository = fipeRepository;
        }

        public async Task<Result<string>> Execute(int id)
        {
            var result = new Result<string>();
            try
            {

                int RowsAffected = await _fipeRepository.Delete(id);

                if (RowsAffected == 0)
                {
                    result = new Result<string>
                    {
                        Sucess = false,
                        Message = "Nenhum fipe foi deletado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<string>
                    {
                        Sucess = true,
                        Message = "removido com sucesso",
                        Data = "Fipe deletado"
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
