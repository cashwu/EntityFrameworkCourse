using System;
using Microsoft.EntityFrameworkCore;

namespace testPostgre
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();

            context.Test.Add(new Test { Id = 1, Name = "abc" });
            context.SaveChanges();
            
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=postgres;UID=sa;PWD=P@ssw0rd");
        }
    }
    
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}