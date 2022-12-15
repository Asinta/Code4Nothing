using Code4Nothing.Blogs.Categories.Dtos;

namespace Code4Nothing.Blogs.Posts.Dtos;

public record PostListDto(
    string Title,
    string Abstract,
    string Author,
    DateTime CreatedAt,
    DateTime? PublishedAt,
    DateTime? LastModifiedAt,
    int Hits,
    int Likes,
    CategoryDto Category,
    List<TagDto> Tags);
