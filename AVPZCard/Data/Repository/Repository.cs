using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVPZCard.Models;
using AVPZCard.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public IndexViewModel GetAllPosts(int pageNumber)
        {
            int pageSize = 5;
            int skipAmount = pageSize * (pageNumber - 1);
            int postCount = _ctx.Posts.Count();


            return new IndexViewModel
            {
                PageNumber = pageNumber,
                CanNextPage = postCount > skipAmount + pageSize,
                Posts = _ctx.Posts
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList()
            };
        }
        public IndexViewModel GetAllPosts(int pageNumber,
            string category,
            string search)
        {

            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category); };

            int pageSize = 5;
            int skipAmount = pageSize * (pageNumber - 1);

            //AsNoTracking не будет отслеживать изменения найденых постов (но увеличивает скорость)
            //последи за сохранением
            var query = _ctx.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query.Where(x => InCategory(x));

            if (!String.IsNullOrEmpty(search))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%")
                || EF.Functions.Like(x.Body, $"%{search}%")
                || EF.Functions.Like(x.Description, $"%{search}%"));


                int postCount = query.Count();

            return new IndexViewModel
            {
                PageNumber = pageNumber,
                CanNextPage = postCount > skipAmount + pageSize,
                Category = category,
                Search = search,
                Posts = query
                    .Skip(skipAmount)
                    .Take(pageSize)
                    .ToList()
        };
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
        if (await _ctx.SaveChangesAsync() != 0)
        {
            return true;
        }
        return false;
    }

}
}
