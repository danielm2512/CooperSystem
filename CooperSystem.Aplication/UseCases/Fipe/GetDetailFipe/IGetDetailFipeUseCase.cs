using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.GetDetailFipe
{
    public interface IGetDetailFipeUseCase
    {
            Task<Result<FipeResponse>> Execute(int id);
    }
}
