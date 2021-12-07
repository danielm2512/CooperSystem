using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.UpdateFipe
{
    public interface IUpdateFipeUseCase
    {
            Task<Result<FipeResponse>> Execute(FipeUpdate fipe);
    }
}
