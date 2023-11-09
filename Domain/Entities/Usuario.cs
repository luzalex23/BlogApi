using Domain.Enuns;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseDomain, IExibivel
    {
        public string Nome { get;  set; }
        public string Email {  get;  set; }
        public string Password {  get;  set; }
        public TipoUser tipo { get;  set; }
        public virtual ICollection<Post> Posts { get; set; }
        public bool CanEditPost(Post post)
        {
            return tipo == TipoUser.Admin || (tipo == TipoUser.Autor && post.AutorId == Id);
        }

        public bool CanDeletePost(Post post)
        {
            return CanEditPost(post);
        }

    }
}
