using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anvi_API.Models
{
    public class Publicacao
    {

        public long Id { get; set; }
        public long? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public long MunicipioId {get; set;}
        
        [ForeignKey(nameof(Municipio.Id))]
        public Municipio? Municipio { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Comentario { get; set; } = string.Empty;
        public int Status { get; set; }
        public string DataPubli { get;set;} =  DateTime.Now.ToString("dd/MM/yyyy");
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
        
    }
}