using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.DeleteMarca
{
    public class DeleteMarcaUseCase : IDeleteMarcaUseCase
    {
        private readonly IMarcaRepository _marcaRepository;

        public DeleteMarcaUseCase(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Result<string>> Execute(int id)
        {
            var result = new Result<string>();
            try
            {

                int RowsAffected = await _marcaRepository.Delete(id);

                if (RowsAffected == 0)
                {
                    result = new Result<string>
                    {
                        Sucess = false,
                        Message = "Nenhuma marca foi deletada",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<string>
                    {
                        Sucess = true,
                        Message = "removido com sucesso",
                        Data = "Marca Deletada"
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
