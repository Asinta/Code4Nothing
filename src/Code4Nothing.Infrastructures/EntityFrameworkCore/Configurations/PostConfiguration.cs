namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts", DbSchema.BlogSchema);
        
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Abstract).HasMaxLength(1024);
        builder.Property(p => p.CreatedAt).HasColumnType("timestamp");
        builder.Property(p => p.LastModifiedAt).HasColumnType("timestamp");
        builder.Property(p => p.PublishedAt).HasColumnType("timestamp");
        builder.Property(p => p.Author).HasMaxLength(64);
        builder.Property(p => p.Slug).HasMaxLength(128);
        builder.Property(p => p.Title).HasMaxLength(128);
        builder.Property(p => p.Content);

        builder.HasIndex(p => p.Title).IsUnique();
    }
}
