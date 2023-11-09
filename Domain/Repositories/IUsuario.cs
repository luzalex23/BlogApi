using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuario : IBaseRepository<Usuario>
    {
        Task<List<Usuario>> GetUserByName(string nome);
        Task<List<Usuario>> GetUserByEmail(string email);
        Task RemoverAutor(List<Usuario> users);


    }
}
