using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.AddMarca
{
    public class AddMarcaUseCase : IAddMarcaUseCase
    {
        private readonly IMarcaRepository _marcaRepository;

        public AddMarcaUseCase(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Result<MarcaResponse>> Execute(MarcaRequest marca)
        {
            var result = new Result<MarcaResponse>();
            try
            {

                var marcaAdicionada = await _marcaRepository.Add(marca);

                if (marcaAdicionada == null)
                {
                    result = new Result<MarcaResponse>
                    {
                        Sucess = false,
                        Message = "Nenhuma marca foi adicionada",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<MarcaResponse>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = marcaAdicionada
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
