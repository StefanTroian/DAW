using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Repositories.DatabaseRepository;
using Dream_house.Repositories.DecorationIdeaRepository;
using Dream_house.Repositories.HomeRepository;
using Dream_house.Repositories.RoomDecorationIdeaRepository;
using Dream_house.Repositories.RoomRepository;
using Dream_house.Repositories.UserRepository;
using Dream_house.Services.DecorationIdeaService;
using Dream_house.Services.DemoService;
using Dream_house.Services.HomeService;
using Dream_house.Services.RoomDecorationIdeaService;
using Dream_house.Services.RoomService;
using Dream_house.Services.UserService;
using Dream_house.Utilities;
using Dream_house.Utilities.Extensions;
using Dream_house.Utilities.JWTUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Dream_house
{
    public class Startup
    {
        private readonly string CorsAllowSpecificOrigin = "frontendAllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dream_house", Version = "v1" });
            });

            services.AddDbContext<DreamHouseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            // service
            services.AddServices();
            services.AddRepositories();

            services.AddCors(option =>
            {
                option.AddPolicy(name: CorsAllowSpecificOrigin, 
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200", "https://localhost:4201")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IDecorationIdeaService, DecorationIdeaService>();
            services.AddScoped<IRoomDecorationIdeaService, RoomDecorationIdeaService>();
            services.AddScoped<IJWTUtils, JWTUtils>();
            
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IHomeRepository, HomeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IDecorationIdeaRepository, DecorationIdeaRepository>();
            services.AddTransient<IRoomDecorationIdeaRepository, RoomDecorationIdeaRepository>();
            services.AddTransient<IDemoService, DemoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dream_house v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // setting for allowing another origin to make request to our server
            app.UseCors(CorsAllowSpecificOrigin);

            app.UseMiddleware<JWTMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
