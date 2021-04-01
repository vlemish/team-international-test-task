using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeamInternationalTestEf.EF;
using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Repos;
using TeamInternationalTestWebApi.Middlwares;
using TeamInternationalTestWebApi.Profiles;
using TeamInternationalTestWebApi.Services;

namespace TeamInternationalTestWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseLazyLoadingProxies(true).UseSqlServer(Configuration.GetConnectionString("sqlServerConnStr"));
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IRepo<User>, UserRepo>();
            services.AddScoped<IRepo<FileMessage>, FileMessageRepo>();
            services.AddScoped<IRepo<TextMessage>, TextMessageRepo>();
            services.AddScoped<IRepo<ImageMessage>, ImageMessageRepo>();
            services.AddScoped<IUserService, UserService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FileMessageProfile());
                mc.AddProfile(new ImageMessageProfile());
                mc.AddProfile(new TextMessageProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            // add initial data to db (a user with username: admin, password: admin).
            app.UseMiddleware<DbInitialiationMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Couldn't find anything");
            });
        }
    }
}
