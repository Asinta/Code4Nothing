namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name).IsRequired().HasMaxLength(256);
        builder.Property(t => t.NormalizedName).IsRequired().HasMaxLength(256);

        builder.HasIndex(t => t.Name).IsUnique();
    }
}
