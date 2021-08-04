using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                var CarroUpdate = _carroRepository.Update(carro);

                if (CarroUpdate.Id == 0 )
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
