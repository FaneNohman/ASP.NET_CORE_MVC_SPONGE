using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication_lesson_2.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Friend> Friends { get; set; }

    }
}
