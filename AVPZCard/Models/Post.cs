using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVPZCard.Models
{
    public class Post
    {
        public int Id { get; set; }
        //Название детали
        public string Title { get; set; } = "";

        //Описание детали
        public string Description { get; set; } = "";
        //Текстовое описание
        public string Body { get; set; } = "";
        //Производитель
        public string Manufacturer { get; set; } = "";

        //Номер детали
        public string DetailNumber { get; set; } = "";

        //название картинки
        public string Image { get; set; } = "";
        //Цена
        public decimal Price { get; set; }

        //В наличии
        public bool IsAble { get; set; }


        public string Tags { get; set; } = "";
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
