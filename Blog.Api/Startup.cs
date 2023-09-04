using Blog.Infra.CrossCutting.IoC;
using DotnetBoilerplate.Components.Api;
using DotnetBoilerplate.Components.Application;
using System.Reflection;

namespace Blog.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddSwaggerGen(x =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                x.IncludeXmlComments(xmlPath);
            });
            var allowedOrigins = Configuration.GetSection("AllowedOrigins").Value;
           
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if(environment == "Development")
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("ClientPermission", policy =>
                    {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(allowedOrigins.Split(";"))
                        .AllowCredentials();
                    });
                });
            }
            services.AddControllers();

            // Boilerplate Dependencies
            services.AddApi();
            services.AddApplication();

            services.AddMongoDb(Configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddAutoMapper(typeof(Startup));      
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("ClientPermission");
            }
       
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
