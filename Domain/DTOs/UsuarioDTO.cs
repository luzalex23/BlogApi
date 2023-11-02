using Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public TipoUser UserType { get; set; }
    }
}
