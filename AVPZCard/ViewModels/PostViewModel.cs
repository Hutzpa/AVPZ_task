using AVPZCard.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        //Название детали
        public string Title { get; set; } = "";
        //Производитель
        public string Manufacturer { get; set; } = "";

        //Номер детали
        public string DetailNumber { get; set; } = "";

        //Текстовое описание
        public string Body { get; set; } = "";
        //Цена
        public decimal Price { get; set; }

        public string CurrentImage { get; set; } = "";


        //В наличии
        public bool IsAble { get; set; }

        //Описание детали
        public string Description { get; set; } = "";

        public string Tags { get; set; } = "";
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public IFormFile Image { get; set; } = null;
    }
}
