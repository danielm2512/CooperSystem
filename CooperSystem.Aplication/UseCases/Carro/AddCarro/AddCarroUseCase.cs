using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.AddCarro
{
    public class AddCarroUseCase : IAddCarroUseCase
    {
        private readonly ICarroRepository _carroRepository;

        public AddCarroUseCase(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Result<CarroResponse>> Execute(CarroRequest carro)
        {
            var result = new Result<CarroResponse>();
            try
            {

                var CarroAdicionado = await _carroRepository.Add(carro);

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
                        Data = CarroAdicionado,
                        Total = 1
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
