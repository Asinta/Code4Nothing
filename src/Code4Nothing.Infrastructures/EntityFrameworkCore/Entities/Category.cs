namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public ICollection<Post> Posts { get; set; }
    
    public Category() => Posts = new HashSet<Post>();
}
