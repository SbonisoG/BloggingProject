using BloggingProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BloggingProject.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { 
                    CategoryId=1,
                    Name="Technology",
                    Description= ""
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Anime",
                    Description = ""
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Football",
                    Description = ""
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId=1,
                    Title="Technology Title Post One",
                    Content= "Content of Technology Post One",
                    Author="John Doe",
                    imagePath="tech_image.jpg",
                    CategoryId=1,
                    PublishedDate = DateTime.UtcNow.Date
                },

                new Post
                {
                    PostId = 2,
                    Title = "Anime Title Post Two",
                    Content = "Content of Anime Post Two",
                    Author = "Jane Doe",
                    imagePath = "anime_image.jpg",
                    CategoryId = 2,
                    PublishedDate = DateTime.UtcNow.Date
                },

                new Post
                {
                    PostId = 3,
                    Title = "Football Title Post Three",
                    Content = "Content of Football Post Three",
                    Author = "Jonathan Doe",
                    imagePath = "football_image.jpg",
                    CategoryId = 3,
                    PublishedDate = DateTime.UtcNow.Date
                }
            );
        }
    }
}
