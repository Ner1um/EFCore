using BlazorBlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure; // For DbSet<>namespace BlazorBlogApp.Data;

public class BlogDataContext : DbContext
 {
     static readonly string connectionString = "Server=localhost; User ID=root; Password=ubuntu; Database=blog";
 
     public DbSet<Author> Authors { get; set; }
     public DbSet<Post> Posts { get; set; }
 
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
     }
     
 }