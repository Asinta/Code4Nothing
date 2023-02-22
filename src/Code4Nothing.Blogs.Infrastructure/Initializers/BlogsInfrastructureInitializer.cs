namespace Code4Nothing.Blogs.Infrastructure.Initializers;

public static class BlogsInfrastructureInitializer
{
    public static void AddBlogsInfrastructuresModule(this IServiceCollection serviceCollection, IConfiguration configuration, IHostEnvironment environment)
    {
        var connectionStr = configuration.GetConnectionString("BlogsDatabase");

        serviceCollection.AddDbContext<Code4NothingBlogsDbContext>(builder =>
        {
            builder
                .UseNpgsql(connectionStr)
                .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: environment.IsDevelopment() ? true : false)
                .EnableDetailedErrors(detailedErrorsEnabled: environment.IsDevelopment() ? true : false);
        });
    }
}