using CooperSystem.Domain.Dto;
using CooperSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.GetAllMarca
{
    public class GetAllMarcaUseCase : IGetAllMarcaUseCase
    {
        private readonly IMarcaRepository _marcaRepository;

        public GetAllMarcaUseCase(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Result<List<MarcaResponse>>> Execute(string nome, string origem)
        {
            var result = new Result<List<MarcaResponse>>();
            try
            {

                var marcas = await _marcaRepository.GetAll(nome, origem);

                if (marcas.Count == 0)
                {
                    result = new Result<List<MarcaResponse>>
                    {
                        Sucess = false,
                        Message = "Nenhuma marca foi encontrada",
                        Data = null
                    };
                }

                else
                {
                    result = new Result<List<MarcaResponse>>
                    {
                        Sucess = true,
                        Message = "Sucess",
                        Data = marcas
                    };
                }

            }
            catch (Exception ex)
            {
                result = new Result<List<MarcaResponse>>
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
