namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Entities;

public class PostTag
{
    public Guid PostId { get; set; }
    public int TagId { get; set; }

    public Post Post { get; set; }
    public Tag Tag { get; set; }
}
