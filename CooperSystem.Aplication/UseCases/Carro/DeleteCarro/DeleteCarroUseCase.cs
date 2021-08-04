using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Carro.DeleteCarro
{
    public class DeleteCarroUseCase : IDeleteCarroUseCase
    {
        private readonly ICarroRepository _carroRepository;

        public DeleteCarroUseCase(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Result<string>> Execute(int id)
        {
            var result = new Result<string>();
            try
            {

                int RowsAffected = await _carroRepository.Delete(id);

                if (RowsAffected == 0 )
                {
                    result = new Result<string>
                    {
                        Sucess = false,
                        Message = "Nenhum carro foi deletado",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<string>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = "Carro deletado"
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<string>
                {
                    Sucess = false,
                    Message = "Erro",
                    Data = null
                };
            }
            return result;
        }
    }
}
