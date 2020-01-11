    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AVPZCard.Models;
using AVPZCard.Data;
using AVPZCard.Data.Repository;
using AVPZCard.Data.FileManager;
using AVPZCard.ViewModels;

namespace AVPZCard.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;
        private AppDbContext _dbContext;

        public HomeController(IRepository repo, 
            IFileManager fileManager,
            AppDbContext dbContext)
        {
            _repo = repo;
            _fileManager = fileManager;
            _dbContext = dbContext;

        }
        public IActionResult PageWithCateg(int pageNumber, int category,string search)
        {
            ViewData["Title"] = "Главная";

            if (pageNumber < 1)
                return RedirectToAction("PageWithCateg", new { pageNumber = 1, category,search });


            var viewModel = _repo.GetAllPosts(pageNumber,category,search);

            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View(_repo.DisplayCategories());
        }
        public IActionResult Contacts()
        {
            ViewData["Title"] = "Контакты";
            if (_dbContext.Abouts.Count() > 0)
            {
                var ps = _dbContext.Abouts.First();
                return View(new AboutViewModel { About = ps.AboutMe, Contacts = ps.Contacts });
            }
            return View();
        }
        public IActionResult AboutMe()
        {
            ViewData["Title"] = "Про меня";
            if (_dbContext.Abouts.Count() > 0)
            {
                var ps = _dbContext.Abouts.First();
                return View(new AboutViewModel { About = ps.AboutMe, Contacts = ps.Contacts });
            }
            return View();
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            ViewData["Title"] = "Про меня";
            return View(post);
        }
        
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

    }
}
