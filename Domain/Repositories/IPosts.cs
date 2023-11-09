using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPosts:IBaseRepository<Post>
    {
        Task<List<Post>> GetAllPostsAsync();
        Task <List<Post>> GetPostsByAuthor(int autorId);

    }
}
