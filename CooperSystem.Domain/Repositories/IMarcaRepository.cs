using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Repositories
{
    public interface IMarcaRepository
    {
        Task<MarcaResponse> Add(MarcaRequest marca);
        Task<int> Delete(int id);
        Task<List<MarcaResponse>> GetAll(string nome, string origem);
        Task<MarcaResponse> GetDetail(int id);
        Task<MarcaResponse> Update(MarcaUpdate marca);
    }
}
