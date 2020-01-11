using AVPZCard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPZCard.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50403_AvtoDatchiki;User Id=DB_A50403_AvtoDatchiki_admin;Password=1Password_;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>()
                .HasOne(o => o.Category)
                .WithMany(c => c.PostsThisCategory)
                .OnDelete(DeleteBehavior.Cascade);

            //DeleteBehavior.Restrict: зависимая сущность никак не изменяется при удалении главной сущности
            //DeleteBehavior.SetNull: свойство-внешний ключ в зависимой сущности получает значение null
            //DeleteBehavior.Cascade: зависимая сущность удаляется вместе с главной
        }
    }
}
