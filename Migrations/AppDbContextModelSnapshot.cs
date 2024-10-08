﻿// <auto-generated />
using System;
using Anvi_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Anvi_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Anvi_API.Models.Imagem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CaminhoImg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("PublicacaoId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PublicacaoId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Anvi_API.Models.Municipio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("Anvi_API.Models.Publicacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DataPubli")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("MunicipioId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("Anvi_API.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("DataCadastro")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdm")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Anvi_API.Models.Imagem", b =>
                {
                    b.HasOne("Anvi_API.Models.Publicacao", "Publicacao")
                        .WithMany("Imagens")
                        .HasForeignKey("PublicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("Anvi_API.Models.Publicacao", b =>
                {
                    b.HasOne("Anvi_API.Models.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anvi_API.Models.Usuario", "Usuario")
                        .WithMany("Publicacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Municipio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Anvi_API.Models.Publicacao", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Anvi_API.Models.Usuario", b =>
                {
                    b.Navigation("Publicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
