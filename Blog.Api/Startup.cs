﻿using Blog.Api.Controllers.Responses;
using Blog.Application.Pagination;
using Blog.Domain.Notifications;
using Blog.Infra.CrossCutting.IoC;
using System.Reflection;

namespace Blog.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            try
            {
                Configuration = configuration;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message + e.StackTrace);
            }
           
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

            services.AddMongoDb(Configuration);
            services.AddControllers();
            services.AddRepositories();
            services.AddServices();

            services.AddScoped<NotificationContext>();
            services.AddScoped<IResponseFactory, ResponseFactory>();
            services.AddScoped(typeof(IPaginationResponse<>), typeof(PaginationResponse<>));
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {               
                app.UseCors("ClientPermission");
            }

       
            app.UseCors("ClientPermission");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
