using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Anvi_API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){
        }
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Publicacao> Publicacoes {get;set;}

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

    }
}