using CooperSystem.Domain.Dto;
using CooperSystem.WebApi.Serialization;
using System.Net;

namespace CooperSystem.WebApi.Presenter
{
    public class Presenters
    {
        public JsonContentResult ContentResult { get; }

        public Presenters()
        {
            ContentResult = new JsonContentResult();
        }

        public void Populate<T>(Result<T> dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
                return;
            }
            if (dto.Message.StartsWith("Erro"))
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.InternalServerError);
                ContentResult.Content = JsonSerializer.SerializeObject(dto.Message);
                return;
            }
            if (dto.Message == null || dto.Sucess == false)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.BadRequest);
                ContentResult.Content = JsonSerializer.SerializeObject(dto.Message);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
    }
}
