using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.imagem;
using Anvi_API.Models;

namespace Anvi_API.Dtos.publicacao
{
    public class PublicacaoDto
    {
        public long Id { get; set; }
        public long? UsuarioId { get; set; }
        public long MunicipioId {get; set;}
        public string Titulo { get; set; } = string.Empty;
        public string Comentario { get; set; } = string.Empty;
        public int Status { get; set; }
        public string DataPubli { get;set;} =  DateTime.Now.ToString("dd/MM/yyyy");
        public List<ImagemDto>? Imagens { get; set; }
        
    }
}