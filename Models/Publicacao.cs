using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Anvi_API.Models
{
    public class Publicacao
    {

        public long Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string comentario { get; set; } = string.Empty;
        public int Status { get; set; }
        
        [ForeignKey(nameof(Municipio.Id))]
        public Municipio? Municipio { get; set; }
        public long? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
        
    }
}