using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.UpdateCarro
{
    public interface IUpdateCarroUseCase
    {
        Task<Result<CarroResponse>> Execute(CarroUpdate carro);
    }
}
