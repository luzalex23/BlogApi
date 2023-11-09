using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post : BaseDomain
    {
        public int AutorId { get; set; }
        public  Usuario Autor {  get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string? ImagemPost { get; set;}
        public bool CanBeEditedOrDeletedBy(Usuario user)
        {
            return user.CanEditPost(this);
        }

    }
}
