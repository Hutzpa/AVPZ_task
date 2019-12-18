using AVPZCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.ViewModels
{
    public class IndexViewModel
    {
       public IEnumerable<Post> Posts { get; set; }
        public int PageNumber { get; set; }
        public Category Category { get; set; }
        public int PageCount { get; set; }
        public string Search { get; set; }
        public bool CanNextPage { get; set; }
    }
}
