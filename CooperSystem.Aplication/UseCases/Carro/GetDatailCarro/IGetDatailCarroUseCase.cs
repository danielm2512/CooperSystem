using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.GetDatailCarro
{
    public interface IGetDatailCarroUseCase
    {
        Task<Result<CarroResponse>> Execute(int id);
    }
}
