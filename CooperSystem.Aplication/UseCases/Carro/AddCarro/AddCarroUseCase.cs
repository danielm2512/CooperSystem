using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                var CarroAdicionado = _carroRepository.Add(carro);

                if (CarroAdicionado.Id == 0 )
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
