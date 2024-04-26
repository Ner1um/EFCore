/*
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorBlogApp.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
    // ... other configurations
    
    builder.Services.AddDbContext<BlogDataContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IBlogService, BlogService>();
*/
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorBlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// ... other configurations

builder.Services.AddDbContext<BlogDataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 31)));
});

builder.Services.AddScoped<IBlogService, BlogService>();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
Console.Write("Hello world");
var author = new Author
{
  Name = "J.K. Rowling",
  Email = "jkrowling@example.com",
  Posts = new List<Post>
  {
      new Post
      {
          Title = "The Philosopher's Stone",
          Content = "A magical story about a young wizard.",
      },
      new Post
      {
          Title = "The Chamber of Secrets",
          Content = "Another thrilling adventure in the wizarding world.",
      }
  }
};
using (var context = new BlogDataContext()) // Creates an instance of BlogDataContext
{
  context.Authors.Add(author); // Adds the author and related posts to the context
  context.SaveChanges(); // Saves the changes to the database
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
