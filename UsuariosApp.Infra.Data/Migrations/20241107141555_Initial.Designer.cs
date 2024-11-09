﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsuariosApp.Infra.Data.Contexts;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241107141555_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("TB_PERFIL", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.PerfilPermissao", b =>
                {
                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PERFIL_ID");

                    b.Property<Guid>("PermissaoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PERMISSAO_ID");

                    b.HasKey("PerfilId", "PermissaoId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("TB_PERFIL_PERMISSAO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("TB_PERMISSAO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<Guid?>("PerfilId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PERFIL_ID");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SENHA");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.PerfilPermissao", b =>
                {
                    b.HasOne("UsuariosApp.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Permissoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UsuariosApp.Domain.Entities.Permissao", "Permissao")
                        .WithMany("Perfis")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("UsuariosApp.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Permissoes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("UsuariosApp.Domain.Entities.Permissao", b =>
                {
                    b.Navigation("Perfis");
                });
#pragma warning restore 612, 618
        }
    }
}
