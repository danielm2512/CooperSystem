using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.UpdateMarca
{
    public class UpdateMarcaUseCase : IUpdateMarcaUseCase
    {
        private readonly IMarcaRepository _marcaRepository;

        public UpdateMarcaUseCase(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Result<MarcaResponse>> Execute(MarcaUpdate marca)
        {
            var result = new Result<MarcaResponse>();
            try
            {

                var marcaAtualizada = await _marcaRepository.Update(marca);

                if (marcaAtualizada == null)
                {
                    result = new Result<MarcaResponse>
                    {
                        Sucess = false,
                        Message = "Nenhuma marca foi atualizada",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<MarcaResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = marcaAtualizada,
                        Total = 1
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<MarcaResponse>
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
