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
    /// Mapeamento da entidade usuário para o banco de dados.
    /// </summary>
    public class usuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS"); //NOME DA TABELA NO BANCO DE DADOS
            builder.HasKey(u => u.Id); //CHAVE PRIMÁRIA

            //configurações dos campos.
            builder.Property(u => u.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            //definir o campo email como unico
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(u => u.PerfilId)
                .HasColumnName("PERFIL_ID")
                .IsRequired();

            //Mapeamento do relacionamento entre Usuario e Perfil (1 para muitos)
            builder.HasOne(u => u.Perfil) //um usuário tem um perfil
                .WithMany(p => p.Usuarios) //um perfil tem muitos usuários
                .HasForeignKey(u => u.PerfilId); //chave estrangeira na tabela usuário               

        }
    }
}
