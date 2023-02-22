namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Slug).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Author).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Abstract).HasMaxLength(1000);

        builder.HasOne(p => p.Category).WithMany(t => t.Posts).HasForeignKey(p => p.CategoryId).IsRequired();
        builder.HasMany(p => p.Tags).WithMany(t => t.Posts);

        builder.HasIndex(p => p.Title).IsUnique();
        builder.HasIndex(p => p.Slug).IsUnique();
    }
}
