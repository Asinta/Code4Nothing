using Code4Nothing.Blogs.Posts.Dtos;

namespace Code4Nothing.Api.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogsController : ControllerBase
{
    public BlogsController()
    {
        
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<PostListDto>>> GetPaginatedPosts()
    {
        return Empty;
    }
}
