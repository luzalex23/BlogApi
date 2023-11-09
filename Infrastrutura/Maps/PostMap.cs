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
    public class PostMap : BaseDomainMap<Post>
    {
     public PostMap() : base("tb_posts")  {}

        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Titulo).HasColumnName("titulo").HasMaxLength(30).IsRequired();
            builder.Property(p => p.Conteudo).HasColumnName("conteudo").IsRequired();
            // Relacionamento entre Post e User (uma postagem pertence a um usuário)

            builder.HasOne(p => p.Autor).WithMany(x => x.Posts).HasForeignKey(x => x.AutorId);

        }
    }
}
