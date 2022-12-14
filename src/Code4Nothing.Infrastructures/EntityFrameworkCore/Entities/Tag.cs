namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public ICollection<Post> Posts { get; set; }

    public Tag() => Posts = new HashSet<Post>();
}
