using Blog.Api;

var builder = WebApplication.CreateBuilder(args);


    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5090, listenOptions => listenOptions.UseHttps());
        options.ListenAnyIP(5091, listenOptions => listenOptions.UseHttps());
    });

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

app.Run();
