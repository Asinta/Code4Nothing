namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Entities;

public class Post : Entity
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Author { get; set; }
    public bool IsFixedToTop { get; set; }
    public string Abstract { get; set; }
    public string Content { get; set; }
    public string CopyrightInfo { get; set; }
    public int Likes { get; set; }
    public int Hits { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Tag> Tags { get; set; }
    
    public Post() => Tags = new HashSet<Tag>();
}
