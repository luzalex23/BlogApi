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
        public virtual ICollection<Autor> Autores { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
