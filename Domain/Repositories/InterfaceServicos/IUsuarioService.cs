using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.InterfaceServicos
{
    public interface IUsuarioService
    {
        Task AddUser(Usuario usuario);
        Task UpdateUser(Usuario usuario);
        Task DeleteUser(Usuario usuario);
    }
}
