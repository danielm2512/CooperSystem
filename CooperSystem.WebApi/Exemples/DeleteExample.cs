using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace CooperSystem.WebApi.Examples
{
    public sealed class DeleteExample : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            return new Result<string>
            {
                Sucess = true,
                Message = "removido com sucesso",
            };
        }
    }
}
