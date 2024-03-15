using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.publicacao;
using Anvi_API.Models;

namespace Anvi_API.Dtos.usuario
{
    public class UsuarioDto
    {
        public long Id { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;
        // public string Cpf { get; set; } = string.Empty;

        // public string Cnpj{ get; set; } = string.Empty;

        public string Email{ get; set; } = string.Empty;

        // public string Senha{ get; set; } = string.Empty;
        public string DataCadastro { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public bool IsAdm { get; set;} = false;
        
         public List<PublicacaoDto> Publicacoes { get; set;}
    }
}