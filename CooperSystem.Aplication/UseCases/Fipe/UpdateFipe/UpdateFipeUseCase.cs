using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.UpdateFipe
{
    public class UpdateFipeUseCase : IUpdateFipeUseCase
    {
        private readonly IFipeRepository _fipeRepository;

        public UpdateFipeUseCase(IFipeRepository fipeRepository)
        {
            _fipeRepository = fipeRepository;
        }

        public async Task<Result<FipeResponse>> Execute(FipeUpdate fipe)
        {
            var result = new Result<FipeResponse>();
            try
            {

                var fipeUpdate = await _fipeRepository.Update(fipe);

                if (fipeUpdate == null)
                {
                    result = new Result<FipeResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum fipe foi atualizado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<FipeResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = fipeUpdate
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<FipeResponse>
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

