using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Autor : BaseDomain, IExibivel
    {
        public Autor() { }
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
