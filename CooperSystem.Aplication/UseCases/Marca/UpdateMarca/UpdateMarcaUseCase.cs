using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                var marcaAtualizada = _marcaRepository.Update(marca);

                if (marcaAtualizada == 0)
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
                        Data = marcaAtualizada
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
