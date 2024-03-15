using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.publicacao;
using Anvi_API.Models;

namespace Anvi_API.Mappers
{
    public static class PublicacaoMappers
    {
        public static PublicacaoDto ToPublicacaoDto(this Publicacao publicacaoModel){
            return new PublicacaoDto{
            Id = publicacaoModel.Id,
            UsuarioId = publicacaoModel.UsuarioId,
            MunicipioId = publicacaoModel.MunicipioId,
            Titulo = publicacaoModel.Titulo,
            Comentario = publicacaoModel.Comentario,
            Status = publicacaoModel.Status,
            DataPubli = publicacaoModel.DataPubli,
            Imagens = publicacaoModel.Imagens.Select(i => i.ToImagemDto()).ToList()
            };
        }
    }
}