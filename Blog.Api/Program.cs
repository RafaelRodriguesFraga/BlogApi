using Blog.Api;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:5090");

//if (builder.Environment.IsProduction())
//{

//    builder.WebHost.ConfigureKestrel(options =>
//    {
//        options.ListenAnyIP(5090);
//        options.ListenAnyIP(5091);
//    });
//}



var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

app.Run();
