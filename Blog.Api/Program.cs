using Blog.Api;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services);

    var app = builder.Build();
    startup.Configure(app, app.Environment);

    app.Run();

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message + ex.StackTrace);
}

