using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("TB_PERFIL_PERMISSAO");

            builder.HasKey(p => new { p.PerfilId , p.PermissaoId });

            builder.Property(p => p.PerfilId)
                .HasColumnName("PERFIL_ID");

            builder.Property(p => p.PermissaoId)
                .HasColumnName("PERMISSAO_ID");

            builder.HasOne(p => p.Perfil)
                .WithMany(p => p.Permissoes)
                .HasForeignKey(p => p.PerfilId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Permissao)
                .WithMany(p => p.Perfis)
                .HasForeignKey(p => p.PermissaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
