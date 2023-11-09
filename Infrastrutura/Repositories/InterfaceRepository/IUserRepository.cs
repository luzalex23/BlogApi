using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Repositories.InterfaceRepository
{
    public interface IUserRepository
    {
        void addUser(Usuario usuario);
        void removeUser(Usuario usuario);
        void upadateUser(Usuario usuario);
        Usuario GetUserId(int userId);
        Usuario GetUserName(string userName);
    }
}
