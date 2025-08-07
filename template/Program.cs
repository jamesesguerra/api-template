
// WebApplication.CreateBuilder creates a new WebApplicationBuilder class and passes the args
// At this point, no WebApplication instance is created yet, because it's a static method
var builder = WebApplication.CreateBuilder(args); 
builder.WebHost.UseUrls("http://0.0.0.0:8082");
// Add services to the container.
// Adds service descriptors to the HostApplicationBuilder's IServiceCollection (a list of instructions on how to construct services)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// At this point, the service descriptors should be finalized before the app is built, as there's no turning back
// you're not supposed to modify the DI services after the app has been built.
// 
// builder.Build() creates a fully-built IHost that finalizes the services and turns the IServiceCollection into a ServiceProvider,
// prepares all the configuration, logging, environment, etc. and for the app to be run, and wraps it in a WebApplication instance
// 
// Wrapping it in a WebApplication gives you access to app.Services, app.Use() - middleware configuration, and app.Run()
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
