using AVPZCard.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.ViewModels
{
    public class CategoryViewModel
    {
        public int Id_Category { get; set; }
        public string CategoryName { get; set; } = "";
        public string CategoryDescription { get; set; } = "";

        public string Photo { get; set; } = "";

        public bool Visible { get; set; }

        public List<Post> PostsThisCategory { get; set; }

        public IFormFile Image { get; set; }
    }
}
