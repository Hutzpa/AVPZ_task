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

        public HomeController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult PageWithCateg(int pageNumber, string category,string search)
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
            return View();
        }
        public IActionResult AboutMe()
        {
            ViewData["Title"] = "Про меня";
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
