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
