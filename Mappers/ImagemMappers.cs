using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.imagem;
using Anvi_API.Models;

namespace Anvi_API.Mappers
{
    public static class ImagemMapper
    {
        public static ImagemDto ToImagemDto(this Imagem imagemModel){
            return new ImagemDto{
                Id = imagemModel.Id,
                CaminhoImg = imagemModel.CaminhoImg
            };
        }
    }
}