namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tags", DbSchema.BlogSchema);
        
        builder.HasMany(p => p.Posts).WithMany(t => t.Tags);
    }
}
