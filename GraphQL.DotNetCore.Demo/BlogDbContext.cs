using GraphQL.DotNetCore.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DotNetCore.Demo
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogdemo.db");
    }
}