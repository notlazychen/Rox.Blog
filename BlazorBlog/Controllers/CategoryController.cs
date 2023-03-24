using BlazorBlog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly BlogDbContext _dbContext;

    public CategoryController(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _dbContext.Categorys
                .Include(x=>x.Posts)
            .Select(x => new CategoryDto
            {
                Id = x.Id,
                Text = x.Text,
                PostsCount = x.Posts.Count,
            })
            .ToListAsync();
    }
}

public class CategoryDto
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public int PostsCount { get; set; }
}
