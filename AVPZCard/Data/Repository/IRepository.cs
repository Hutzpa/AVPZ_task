using AVPZCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);

        List<Post> GetAllPosts();
        List<Post> GetAllPosts(int pageNumber);
        List<Post> GetAllPosts(string category);

        void RemovePost(int id);
        void AddPost(Post post);
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
    }
}
