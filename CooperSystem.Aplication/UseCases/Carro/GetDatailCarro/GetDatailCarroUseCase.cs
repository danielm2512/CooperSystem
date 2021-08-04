using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.GetDatailCarro
{
    public class GetDatailCarroUseCase : IGetDatailCarroUseCase
    {
        private readonly ICarroRepository _carroRepository;

        public GetDatailCarroUseCase(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Result<CarroResponse>> Execute(int id)
        {
            var result = new Result<CarroResponse>();
            try
            {

                var CarroAdicionado = await _carroRepository.GetCarro(id);

                if (CarroAdicionado == null )
                {
                    result = new Result<CarroResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum carro foi adicionado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<CarroResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = CarroAdicionado
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<CarroResponse>
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
