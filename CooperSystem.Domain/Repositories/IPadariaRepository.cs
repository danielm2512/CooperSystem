using CooperSystem.Domain.Dto.Padaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Repositories
{
    public interface IPadariaRepository
    {
        Task<PadariaResponse> Add(PadariaRequest padaria);
        Task<int> Delete(int id);
        Task<List<PadariaResponse>> GetAll(string nome, string origem);
        Task<PadariaResponse> Update(PadariaUpdate produto);
        Task<PadariaResponse> GetDetail(int id);
    }
}
