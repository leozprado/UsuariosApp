using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarContaResponse CriarConta(CriarContaRequest request);
    }
}