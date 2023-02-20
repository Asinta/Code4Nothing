namespace Code4Nothing.Blogs.Domain.Entities;

public class Post
{
    public Post() { }

    public Post(string title, string @abstract, string content, Category category)
    {
        Title = title;
        Slug = title.ToNormalizedString();
        Abstract = @abstract;
        Content = content;
        Category = category;
        CategoryId = category.Id;
    }
    
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Abstract { get; set; }
    public string Content { get; set; }
    public string Author { get; set; } = "code4nothing";

    public long Likes { get; set; } = 0L;
    public long Hits { get; set; } = 0L;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; }
    public DateTime PublishedAt { get; set; }

    public bool IsPublished { get; set; } = false;
    public bool IsToppedUp { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public bool IsOriginal { get; set; } = true;
    
    // Navigation Properties
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}