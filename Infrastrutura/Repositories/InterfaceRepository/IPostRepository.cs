using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Repositories.InterfaceRepository
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        List<Post> GetPostById(int postId);
        List<Post> GetPostsByAuthor(int autorId);


    }
}
