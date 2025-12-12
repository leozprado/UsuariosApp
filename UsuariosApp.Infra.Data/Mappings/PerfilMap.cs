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
    /// <summary>
    /// /
    /// </summary>

    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PERFIS"); //NOME DA TABELA NO BANCO DE DADOS
            builder.HasKey(p => p.Id); //CHAVE PRIMÁRIA
            //configurações dos campos.
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .IsRequired();
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.Nome)
               .IsUnique(); //definindo o campo como unico

           
        }

    }
}
