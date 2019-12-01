using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVPZCard.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
        public decimal Price { get; set; }
        public bool IsAble { get; set; }


        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
