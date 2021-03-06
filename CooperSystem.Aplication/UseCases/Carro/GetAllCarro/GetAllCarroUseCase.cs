using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.GetAllCarro
{
    public class GetAllCarroUseCase : IGetAllCarroUseCase
    {
        private readonly ICarroRepository _carroRepository;

        public GetAllCarroUseCase(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Result<List<CarroGet>>> Execute(string nome, string origem)
        {
            var result = new Result<List<CarroGet>>();
            try
            {

                var getcarro = await _carroRepository.GetAll(nome,origem);

                if (getcarro.Count == 0 )
                {
                    result = new Result<List<CarroGet>>
                    {
                        Sucess = false,
                        Message = "Nenhum carro foi encontrado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<List<CarroGet>>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = getcarro,
                        Total = getcarro.Count
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<List<CarroGet>>
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
