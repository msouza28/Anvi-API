using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Anvi_API.Models
{
    public class Imagem
    {
        public long Id { get; set; }
        public long? PublicacaoId { get; set; }
        public Publicacao? Publicacao {get; set;}
        public string CaminhoImg { get; set; } = string.Empty;
    }
}