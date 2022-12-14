ConfigureLogger(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty);

Log.Information("Starting web host...");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkCoreServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetService<Code4NothingDbContext>();
        
    Log.Logger.Write(LogEventLevel.Information, "Migrating Database...");
    db?.Database.Migrate();
        
    Log.Logger.Write(LogEventLevel.Information, "Seeding Data...");
    // db.SeedData();
}

app.Run("https://0.0.0.0:6000");


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
