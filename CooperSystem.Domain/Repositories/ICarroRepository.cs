using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<CarroResponse> Add(CarroRequest carro);
        Task<int> Delete(int id);
        Task<List<CarroGet>> GetAll(string nome, string origem);
        Task<CarroResponse> GetCarro(int id);
        Task<CarroResponse> Update(CarroUpdate carro);
    }
}
