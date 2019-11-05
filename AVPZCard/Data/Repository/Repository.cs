using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVPZCard.Models;

namespace AVPZCard.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        public List<Post> GetAllPosts(int pageNumber)
        {
            int pageSize = 5;
            return _ctx.Posts
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
        } 
        public List<Post> GetAllPosts(string category)
        {
            return _ctx.Posts.
                Where(p => p.Category.ToLower().Equals(category.ToLower())).
                ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts.FirstOrDefault(m => m.Id == id);
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
            
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }
        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _ctx.SaveChangesAsync() != 0)
            {
                return true;
            }
            return false;
        }

    }
}
