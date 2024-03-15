using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anvi_API.Dtos.usuario
{
    public class UpdateUsuarioRequestDto
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public string Cnpj{ get; set; } = string.Empty;

        public string Email{ get; set; } = string.Empty;

        public string Senha{ get; set; } = string.Empty;
        public bool IsAdm { get; set; }
        
    }
}