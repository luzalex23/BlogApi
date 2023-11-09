using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Maps
{
    public class UsuarioMap : BaseDomainMap<Usuario>
    {
        public UsuarioMap() : base("tb_user") { }
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Tipo).HasColumnName("tipo").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(100).IsRequired();

            // Relacionamento entre User e Post (um usuário pode ter várias postagens)
            builder.HasMany(x => x.Posts).WithOne(p => p.Autor).HasForeignKey(p => p.AutorId);

        }

    }
}
