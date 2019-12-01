using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.Models
{
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        public string CategoryName { get; set; } = "";
        public string CategoryDescription { get; set; } = "";

        public string Photo { get; set; } = "";

        public bool Visible { get; set; }

        public List<Post> PostsThisCategory { get; set; }
    }
}
