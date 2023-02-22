namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        
    }
}
