using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.UpdateCarro
{
    public class UpdateCarroUseCase : IUpdateCarroUseCase
    {
        private readonly ICarroRepository _carroRepository;

        public UpdateCarroUseCase(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Result<CarroResponse>> Execute(CarroUpdate carro)
        {
            var result = new Result<CarroResponse>();
            try
            {

                var CarroUpdate = await _carroRepository.Update(carro);

                if (CarroUpdate == null )
                {
                    result = new Result<CarroResponse>
                    {
                        Sucess = false,
                        Message = "Nenhum carro foi atualizado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<CarroResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = CarroUpdate
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
