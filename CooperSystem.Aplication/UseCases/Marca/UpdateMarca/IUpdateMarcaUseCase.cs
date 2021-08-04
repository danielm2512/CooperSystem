﻿using CooperSystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Application.UseCases.Marca.UpdateMarca
{
    public interface IUpdateMarcaUseCase
    {
        Task<Result<MarcaResponse>> Execute(MarcaUpdate marca);
    }
}
