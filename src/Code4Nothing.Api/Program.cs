ConfigureLogger(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty);

Log.Information("Starting web host...");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddEntityFrameworkCoreServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

await MigrateDatabaseAsync(app);

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

await app.RunAsync();

#region Helpers

static void ConfigureLogger(string currentEnvironment)
{
    var isProductionEnvironment = currentEnvironment.Equals("Production");

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Is(isProductionEnvironment ? LogEventLevel.Information : LogEventLevel.Debug)
        .MinimumLevel.Override("Microsoft", isProductionEnvironment ? LogEventLevel.Warning : LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", isProductionEnvironment ? LogEventLevel.Information : LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();
}

async Task MigrateDatabaseAsync(IHost webApplication)
{
    using var scope = webApplication.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<Code4NothingDbContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during migration");
    }
}

#endregion
