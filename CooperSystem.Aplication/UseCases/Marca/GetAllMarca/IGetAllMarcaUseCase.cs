using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.GetAllMarca
{
    public interface IGetAllMarcaUseCase
    {
        Task<Result<List<MarcaResponse>>> Execute(string nome, string origem);
    }
}
