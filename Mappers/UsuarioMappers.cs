using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.usuario;
using Anvi_API.Models;

namespace Anvi_API.Mappers
{
    public static class UsuarioMappers
    {
       public static UsuarioDto ToUsuarioDto(this Usuario usuario){
        return new UsuarioDto{
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            DataCadastro = usuario.DataCadastro,
            IsAdm = usuario.IsAdm,
            Publicacoes = usuario.Publicacoes.Select(p => p.ToPublicacaoDto()).ToList()
        };
       } 
    
    public static Usuario ToUsuarioFromCreateUsuarioRequestDto(this CreateUsuarioRequestDto requestDto ){
        return new Usuario{
            NomeCompleto = requestDto.NomeCompleto,
            Cpf = requestDto.Cpf,
            Cnpj = requestDto.Cnpj,
            Email = requestDto.Email,
            Senha = requestDto.Senha,
            };
        }

    }
}