using CooperSystem.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace CooperSystem.WebApi.Examples
{
    public sealed class ResultErrorExample : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            return new Result<string>
            {
                Sucess = false,
                Data = "MessageError",
            };
        }
    }
}
