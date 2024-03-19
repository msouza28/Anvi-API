using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.usuario;
using Anvi_API.Models;

namespace Anvi_API.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> GetAllUsuariosAsync();

        public Task<Usuario?> GetUsuarioByIdAsync(long id);

        public Task<Usuario> CreateUsuarioAsync(Usuario usuarioModel);

        public Task<Usuario?> UpdateUsuarioAsync(long id, UpdateUsuarioRequestDto requestDto);

        public Task<Usuario?> DeleteUsuario(long id);

        public Task<bool> UsuarioExiste(long id);
    }
}