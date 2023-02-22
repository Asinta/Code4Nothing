namespace Code4Nothing.Blogs.Domain.Entities;

public record Post : BaseDomainEntity
{
    private Post()
    {
        Tags = new HashSet<Tag>();
    }

    public Post(string title, string @abstract, string content, Category category)
    {
        Id = Guid.NewGuid();
        Title = title;
        Slug = title.ToNormalizedString();
        Abstract = @abstract;
        Content = content;
        Category = category;
        Author = PostConfigurationConsts.PostAuthor;
    }
    
    public Post(string title, string slug, string @abstract, string content, Category category)
    {
        Id = Guid.NewGuid();
        Title = title;
        Slug = slug;
        Abstract = @abstract;
        Content = content;
        Category = category;
        Author = PostConfigurationConsts.PostAuthor;
    }
    
    public Guid Id { get; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Abstract { get; private set; }
    public string Content { get; private set; }
    public string Author { get; }
    public long Likes { get; private set; }
    public long Hits { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime PublishedAt { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsToppedUp { get; private set; }
    public bool IsDeleted { get; private set; }
    
    // Navigation Properties
    public ICollection<Tag> Tags { get; private set; }
    
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public void IncreaseLikes() => Likes += 1;
    public void IncreaseHits() => Hits += 1;
    public void UpdateTitle(string newTitle)
    {
        Title = newTitle;
        Slug = newTitle.ToNormalizedString();
    }
    public void UpdateSlug(string newSlug) => Slug = newSlug;
    public void UpdateAbstract(string newAbstract) => Abstract = newAbstract;
    public void UpdateContent(string newContent) => Content = newContent;
    public void PublishPost()
    {
        PublishedAt = DateTime.UtcNow;
        IsPublished = true;
    }
    public void DeletePost() => IsDeleted = true;
    public void ToggleToppedUpState() => IsToppedUp = !IsToppedUp;
    public void UpdateTags(List<Tag> newTags) => Tags = newTags;
    public void UpdateCategory(Category newCategory) => Category = newCategory;
}
