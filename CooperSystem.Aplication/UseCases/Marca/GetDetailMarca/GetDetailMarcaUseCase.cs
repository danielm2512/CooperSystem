using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.GetDetailMarca
{
    public class GetDetailMarcaUseCase : IGetDetailMarcaUseCase
    {
        private readonly IMarcaRepository _marcaRepository;

        public GetDetailMarcaUseCase(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Result<MarcaResponse>> Execute(int id)
        {
            var result = new Result<MarcaResponse>();
            try
            {

                var marca = await _marcaRepository.GetDetail(id);

                if (marca == null)
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
                        Data = marca
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
