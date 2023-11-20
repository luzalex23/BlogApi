using Domain.Entities;
using Infrastrutura.Data;
using Infrastrutura.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddPost(Post post)
        {
            _context.Postagens.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Postagens.Find(postId);
            if (post != null)
            {
                _context.Postagens.Remove(post);
                _context.SaveChanges();
            }
        }

       

        public List<Post> GetPostsByAuthor(int autorId)
        {
            return _context.Postagens.Where(p => p.AutorId == autorId).ToList();
        }

        public void UpdatePost(Post post)
        {
            _context.Postagens.Update(post);
            _context.SaveChanges();
        }
    }
}
