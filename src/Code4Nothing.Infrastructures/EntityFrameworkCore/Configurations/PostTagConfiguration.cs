namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Configurations;

public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.ToTable("post_tags", DbSchema.BlogSchema);
        builder.HasKey(pt => new { pt.PostId, pt.TagId });
    }
}
