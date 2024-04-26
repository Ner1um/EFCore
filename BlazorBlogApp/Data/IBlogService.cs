namespace BlazorBlogApp.Data;

public interface IBlogService
{
    Task<List<Author>> GetAuthorsAsync(); 
}