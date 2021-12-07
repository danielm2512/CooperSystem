using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.GetDetailFipe
{
    public class GetDetailFipeUseCase : IGetDetailFipeUseCase
    {
            private readonly IFipeRepository _fipeRepository;

            public GetDetailFipeUseCase(IFipeRepository fipeRepository)
            {
                _fipeRepository = fipeRepository;
            }

            public async Task<Result<FipeResponse>> Execute(int id)
            {
                var result = new Result<FipeResponse>();
                try
                {

                    var FipeVerificado = await _fipeRepository.GetFipe(id);

                    if (FipeVerificado == null)
                    {
                        result = new Result<FipeResponse>
                        {
                            Sucess = false,
                            Message = "Nenhum fipe foi encontrado",
                            Data = null
                        };
                    }

                    else
                    {
                        result = new Result<FipeResponse>
                        {
                            Sucess = true,
                            Message = "Sucess",
                            Data = FipeVerificado,
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

