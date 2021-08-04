using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.GetAllCarro
{
    public interface IGetAllCarroUseCase
    {
        Task<Result<List<CarroGet>>> Execute(string nome, string origem);
    }
}
