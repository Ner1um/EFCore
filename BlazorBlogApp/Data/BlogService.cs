using Microsoft.EntityFrameworkCore;

namespace BlazorBlogApp.Data;

    
public class BlogService : IBlogService
{
    private readonly BlogDataContext _context;

    public BlogService(BlogDataContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.Include(a => a.Posts).ToListAsync();
    }
}