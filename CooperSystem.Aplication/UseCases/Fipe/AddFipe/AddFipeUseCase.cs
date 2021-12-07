using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.AddFipe
{
    public class AddFipeUseCase : IAddFipeUseCase
    {
        private readonly IFipeRepository _fipeRepository;

        public AddFipeUseCase(IFipeRepository fipeRepository)
        {
            _fipeRepository = fipeRepository;
        }

        public async Task<Result<FipeResponse>> Execute(FipeRequest fipe)
        {
            var result = new Result<FipeResponse>();
            try
            {

                var FipeAdicionado = await _fipeRepository.Add(fipe);

                if (FipeAdicionado == null)
                {
                    result = new Result<FipeResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum fipe foi adicionado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<FipeResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = FipeAdicionado,
                        Total = 1
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

