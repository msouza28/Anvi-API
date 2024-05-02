using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anvi_API.Dtos.usuario
{
    public class AutenticacaoUsuarioDto
    {
        

        public string Email{ get; set; } = string.Empty;

        public string Senha{ get; set; } = string.Empty;
    }
}