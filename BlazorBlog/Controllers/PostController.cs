using BlazorBlog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly BlogDbContext _dbContext;

    public PostController(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<List<PostSlimDto>> GetPosts(
        [FromQuery(Name ="cate")]int? cateId, 
        [FromQuery(Name ="s")]string? searchKey,
        [FromQuery]int page=0)
    {
        var q = _dbContext.Posts.AsQueryable();
        if(cateId.HasValue)
        {
            q = q.Where(x => x.CategoryId == cateId);
        }
        if (searchKey != null)
        {
            q = q.Where(x => x.Title.Contains(searchKey));
        }
        return await q.OrderByDescending(p => p.UpdateAt)
            .Skip(page * 10)
            .Take(10)
            .Select(x => new PostSlimDto
            {
                Id = x.Id,
                Title = x.Title,
                PublishAt = x.PublishAt,
            })
            .ToListAsync();
    }

    [HttpGet("{postId}")]
    public async Task<PostDetailDto?> GetPosts([FromRoute]int postId)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if(post == null)
        {
            return null;
        }
        return new PostDetailDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            PublishAt = post.PublishAt,
        };
    }
}

public class PostSlimDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public DateTime PublishAt { get; set; }
}

public class PostDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime PublishAt { get; set; }
}
