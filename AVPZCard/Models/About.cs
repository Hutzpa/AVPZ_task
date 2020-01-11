using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.Models
{
    public class About
    {
        [Key]
        public int Key { get; set; }
        public string AboutMe { get; set; }
        public string Contacts { get; set; }
    }
}
