namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(256);
        builder.Property(c => c.NormalizedName).IsRequired().HasMaxLength(256);

        builder.HasIndex(c => c.Name).IsUnique();
    }
}
