namespace Code4Nothing.Infrastructures;

public static class InfrastructureServices
{
    public static IServiceCollection AddEntityFrameworkCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        services.AddDbContext<Code4NothingDbContext>(optionsAction => optionsAction
            .EnableDetailedErrors()
            .UseNpgsql(configuration.GetConnectionString("Default"), options =>
            {
                options.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
            })
            .UseSnakeCaseNamingConvention());

        return services;
    }
}
