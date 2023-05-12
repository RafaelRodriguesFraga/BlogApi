using Blog.Api;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5090");

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

app.Run();
