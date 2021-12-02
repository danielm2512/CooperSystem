using CooperSystem.Domain.Dto.Fipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Repositories
{
    public interface IFipeRepository
    {
        Task<FipeResponse> Add(FipeRequest fipe);
        Task<int> Delete(int id);
        Task<List<FipeResponse>> GetAll(string nome,string ano);
        Task<FipeResponse> GetFipe(int id);
        Task<FipeResponse> Update(FipeUpdate fipe);
    }
}
