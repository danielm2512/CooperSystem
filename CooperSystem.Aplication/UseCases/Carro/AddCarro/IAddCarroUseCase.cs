using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.AddCarro
{
    public interface IAddCarroUseCase
    {
        Task<Result<CarroResponse>> Execute(CarroRequest carro);
    }
}
