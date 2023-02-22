namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
    }
}
