using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseDomain
    {
        public virtual int Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
