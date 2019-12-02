using AVPZCard.Data;
using AVPZCard.Data.FileManager;
using AVPZCard.Data.Repository;
using AVPZCard.Models;
using AVPZCard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private AppDbContext _dbContext;
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository repo, 
            IFileManager fileManager,
            AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Главная";
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        
        public IActionResult Contacts()
        {
            ViewData["Title"] = "Контакты";
            return View();
        }
        public IActionResult AboutMe()
        {
            ViewData["Title"] = "Про меня";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var v = _dbContext.Categories.ToList();
            ViewBag.Categories = v;
            ViewData["Title"] = "Edit";
            if (id == null)
                return View(new PostViewModel()); 
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    Description = post.Description,
                    Manufacturer = post.Manufacturer,
                    DetailNumber = post.DetailNumber,
                    CurrentImage = post.Image,
                    Price = post.Price,
                    IsAble = post.IsAble,
                    Tags = post.Tags,
                    Category = post.Category,                    
                    
                }) ;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Description = vm.Description,
                Manufacturer = vm.Manufacturer,
                DetailNumber = vm.DetailNumber,
                Price = vm.Price,
                IsAble = vm.IsAble,
                Tags = vm.Tags,
                Category = _dbContext.Categories.FirstOrDefault(o=>o.Id_Category==vm.CategoryId)
            };
            if (vm.Image == null)
                post.Image = vm.CurrentImage;
            else
                post.Image = await _fileManager.SaveImage(vm.Image);

            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
