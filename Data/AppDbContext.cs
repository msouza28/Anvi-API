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


       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração do relacionamento entre Publicacao e Usuario
        modelBuilder.Entity<Publicacao>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Publicacoes)
            .HasForeignKey(p => p.UsuarioId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Ou DeleteBehavior.Cascade se desejar excluir em cascata

        // Configuração do relacionamento entre Publicacao e Municipio
        modelBuilder.Entity<Publicacao>()
            .HasOne(p => p.Municipio)
            .WithMany()
            .HasForeignKey(p => p.MunicipioId)
            .IsRequired();

        // Configuração do relacionamento entre Imagem e Publicacao
        modelBuilder.Entity<Imagem>()
            .HasOne(i => i.Publicacao)
            .WithMany(p => p.Imagens)
            .HasForeignKey(i => i.PublicacaoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Supondo que uma Imagem não faz sentido sem uma Publicacao

        // Configuração da model de Usuario
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Publicacoes)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Ou DeleteBehavior.Cascade se desejar excluir em cascata

        modelBuilder.Entity<Usuario>()
            .Property(u => u.DataCadastro)
            .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Define DataCadastro como um valor padrão de banco de dados

        // Outras configurações de propriedades específicas
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Cpf)
            .HasColumnType("varchar(14)");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Cnpj)
            .HasColumnType("varchar(18)");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Senha)
            .HasColumnType("varchar(100)");
    }

    }
}