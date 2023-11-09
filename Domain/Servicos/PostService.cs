using Domain.Entities;
using Domain.Enuns;
using Domain.Repositories;
using Domain.Repositories.InterfaceServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class PostService : IPostService
    {
        private readonly IPosts _posts;

        public PostService(IPosts posts)
        {
            _posts = posts;
        }

        public async Task AddPost(Usuario usuario, Post post)
        {
            if(usuario.tipo == TipoUser.Autor)
            {
                await _posts.Add(post);
            }
            else
            {
                throw new Exception("Usuário não autorizado para criar postagens.");
            }
        }

        public async Task AtualizaPost(Post post, Usuario usuario)
        {
            if(usuario.Id == post.AutorId)
            {
                await _posts.Update(post);
            }
            else 
            {
                throw new Exception("Somente o Autor pode editar a própria postagem");
            }
        }

        public async Task DeletePost(Post post, Usuario usuario)
        {
            if(usuario.tipo == TipoUser.Admin || usuario.Id == post.AutorId)
            {
                await _posts.Delete(post);
            }
            else
            {
                throw new Exception("Somente o Adminitrador do sistema ou o proprio Autor podera deletar esta postagem");
            }
        }
    }
}
