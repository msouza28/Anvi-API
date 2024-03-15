using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anvi_API.Dtos.imagem
{
    public class ImagemDto
    {
        public long Id { get; set; }
        public long PublicacaoId { get; set; }
        public string CaminhoImg { get; set; } = string.Empty;
    }
}