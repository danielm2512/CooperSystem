using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                var getcarro = _carroRepository.GetAll(nome,origem);

                if (getcarro == null )
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
                        Data = getcarro
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
