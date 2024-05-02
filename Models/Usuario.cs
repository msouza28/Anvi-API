using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.publicacao;

namespace Anvi_API.Models
{
    public class Usuario
    {

        public long Id { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;
        [Column (TypeName = "varchar(14)")]
        public string Cpf { get; set; } = string.Empty;

        [Column (TypeName = "varchar(18)")]
        public string Cnpj{ get; set; } = string.Empty;

        public string Email{ get; set; } = string.Empty;

        [Column (TypeName = "varchar(100)")]
        public string Senha{ get; set; } = string.Empty;
        
        public string DataCadastro { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        public bool IsAdm { get; set;} = false;
        
        public List<Publicacao> Publicacoes { get; set; } = new List<Publicacao>();

    }

}