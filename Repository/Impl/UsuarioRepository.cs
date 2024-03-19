using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Dtos.usuario;
using Anvi_API.Models;
using Anvi_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anvi_API.Repository.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

       public UsuarioRepository(AppDbContext context){
        _context = context;
       }
        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.Include(p => p.Publicacoes).ToListAsync();
        }
        public  async Task<Usuario?> GetUsuarioByIdAsync(long id)
        {
            return await _context.Usuarios.Include(p => p.Publicacoes).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuarioModel)
        {
            await _context.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }
        public async Task<Usuario?> UpdateUsuarioAsync(long id, UpdateUsuarioRequestDto requestDto)
        {
            var usuarioById= await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if(usuarioById == null){
                return null;
            }
            usuarioById.NomeCompleto = requestDto.NomeCompleto == "" ? usuarioById.NomeCompleto: requestDto.NomeCompleto;
            if(usuarioById.Cpf.Equals("")){
                usuarioById.Cnpj = requestDto.Cnpj == "" ? usuarioById.Cnpj : requestDto.Cnpj;
            } else {
                usuarioById.Cpf = requestDto.Cpf == "" ? usuarioById.Cpf : requestDto.Cpf;
            }
            usuarioById.Email = requestDto.Email == "" ? usuarioById.Email : requestDto.Email;
            usuarioById.Senha = requestDto.Senha == "" ? usuarioById.Senha : requestDto.Senha;

            if(usuarioById.IsAdm != requestDto.IsAdm){
            usuarioById.IsAdm = requestDto.IsAdm;  
            }
            
            usuarioById.DataCadastro = usuarioById.DataCadastro;

           await _context.SaveChangesAsync();
           return usuarioById;
        }
        public async Task<Usuario?> DeleteUsuario(long id)
        {
            var usuarioById = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if(usuarioById == null){
                return null;
            }
            _context.Usuarios.Remove(usuarioById);
            await _context.SaveChangesAsync();

            return usuarioById;
        }

        public async Task<bool> UsuarioExiste(long id)
        {
            return  await _context.Usuarios.AnyAsync(u => u.Id == id);
        }
    }
}