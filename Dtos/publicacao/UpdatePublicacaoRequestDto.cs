using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.imagem;

namespace Anvi_API.Dtos.publicacao
{
    public class UpdatePublicacaoRequestDto
    {
        public long MunicipioId {get;set;}
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public int Status { get; set; }
        public List<CreateImagemRequestDto> ImagensDto { get; set; }
    }
}