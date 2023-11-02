using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
    }
}
