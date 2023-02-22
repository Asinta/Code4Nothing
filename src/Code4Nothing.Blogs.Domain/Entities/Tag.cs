namespace Code4Nothing.Blogs.Domain.Entities;

public record Tag : BaseDomainEntity
{
    private Tag() { }

    public Tag(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        NormalizedName = name.ToNormalizedString();
        Posts = new HashSet<Post>();
    }

    public Tag(string name, string normalizedName)
    {
        Id = Guid.NewGuid();
        Name = name;
        NormalizedName = normalizedName;
        Posts = new HashSet<Post>();
    }
    
    
    public Guid Id { get; }
    public string Name { get; private set; }
    public string NormalizedName { get; private set; }
    
    // Navigation Property
    public virtual ICollection<Post> Posts { get; private set; }

    public void ChangeName(string newName)
    {
        Name = newName;
        NormalizedName = newName.ToNormalizedString();
    }

    public void ChangeNormalizedName(string normName)
    {
        NormalizedName = normName;
    }
}
