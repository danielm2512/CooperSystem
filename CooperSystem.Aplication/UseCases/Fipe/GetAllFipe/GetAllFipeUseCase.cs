using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.GetAllFipe
{
    public class GetAllFipeUseCase : IGetAllFipeUseCase
    {
        private readonly IFipeRepository _fipeRepository;

        public GetAllFipeUseCase(IFipeRepository fipeRepository)
        {
            _fipeRepository = fipeRepository;
        }

        public async Task<Result<List<FipeResponse>>> Execute(string nome, string ano)
        {
            var result = new Result<List<FipeResponse>>();
            try
            {

                var getFipes = await _fipeRepository.GetAll(nome, ano);

                if (getFipes.Count() == 0)
                {
                    result = new Result<List<FipeResponse>>
                    {
                        Sucess = false,
                        Message = "Nenhum fipe foi encontrado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<List<FipeResponse>>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = getFipes,
                        Total = getFipes.Count()
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<List<FipeResponse>>
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

