using AVPZCard.Models;
using AVPZCard.ViewModels;
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
  
        IndexViewModel GetAllPosts(int pageNumber, int category,string search);

        void RemovePost(int id);
        void AddPost(Post post);
        void UpdatePost(Post post);

        void UpdateInf(AboutViewModel vm);

        IEnumerable<Category> DisplayCategories();

        Task<bool> SaveChangesAsync();
    }
}
