using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Dto.Fipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Fipe.AddFipe
{
    public interface IAddFipeUseCase
    {
        Task<Result<FipeResponse>> Execute(FipeRequest fipe);
    }
}
