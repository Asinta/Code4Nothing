namespace Code4Nothing.Blogs.Domain.Entities;

public class Tag
{
    public Tag()
    {
        Id = Guid.NewGuid();
        Posts = new HashSet<Post>();
    }

    public Tag(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        NormalizedName = name.ToNormalizedString();
        Posts = new HashSet<Post>();
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    
    // Navigation Property
    public virtual ICollection<Post> Posts { get; set; }
}