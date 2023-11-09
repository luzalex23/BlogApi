using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.InterfaceServicos
{
    public interface IPostService
    {
        Task AddPost(Usuario autor, Post post);
        Task AtualizaPost(Post post, Usuario usuario);
        Task DeletePost(Post post, Usuario usuario);
    }
}
