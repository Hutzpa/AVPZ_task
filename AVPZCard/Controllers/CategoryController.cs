using AVPZCard.Data;
using AVPZCard.Data.FileManager;
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
    public class CategoryController : Controller
    {
        private AppDbContext _appDbContext;
        private IFileManager _fileManager;

        public CategoryController(AppDbContext appDbContext, IFileManager fileManager)
        {
            _appDbContext = appDbContext;
            _fileManager = fileManager;
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new CategoryViewModel());
            }
            else
            {
                var cat = _appDbContext.Categories.FirstOrDefault(o => o.Id_Category == (int)id);
                return View(new CategoryViewModel
                {
                    Id_Category = cat.Id_Category,
                    CategoryName = cat.CategoryName,
                    CategoryDescription = cat.CategoryDescription,
                    Photo = cat.Photo,
                    Visible = cat.Visible,

                });
            }
            //Добавить CATEGORYVIEWMODEL ДЛЯ ОТОБРАЖЕНИЯ КАРТИНОК С КАТЕГОРИЯМИ
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel cat)
        {
            var post = new Category
            {
                Id_Category = cat.Id_Category,
                CategoryName = cat.CategoryName,
                CategoryDescription = cat.CategoryDescription,
                Photo = cat.Photo,
                Visible = cat.Visible
            };
            if (cat.Image == null)
                post.Photo = cat.Photo;
            else
                post.Photo = await _fileManager.SaveImage(cat.Image);

            if (post.Id_Category > 0)
                _appDbContext.Update(post);
            else
                _appDbContext.Categories.Add(post);


            if (await _appDbContext.SaveChangesAsync() != 0)
                return RedirectToAction("CategoryList", "Category");
            else
                return View(post);
        }


        public IActionResult CategoryList()
        {
            return View(_appDbContext.Categories.ToList());
        }

        public IActionResult ShowEnableCategories()
        {
            return View(_appDbContext.Categories.Where(o => o.Visible == true).ToList());
        }

        public async Task<IActionResult> RemoveAsync(int id)
        {
            _appDbContext.Categories.Remove(
                _appDbContext.Categories.FirstOrDefault(o => o.Id_Category == id));
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }

    }
}
