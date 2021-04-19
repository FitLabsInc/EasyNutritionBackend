using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyNutrition.API.Domain.Persistence.Contexts;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Extensions;
using EasyNutrition.API.Persistence.Repositories;
using EasyNutrition.API.Resources;
using EasyNutrition.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EasyNutrition.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("easynutrition-api-in-memory");
                options.UseMySQL(Configuration.GetConnectionString("MySQLConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8080");
                                  });

               options.AddPolicy("AnotherPolicy",
               builder =>
               {
                   builder.WithOrigins("http://localhost:8080")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
               });
            });

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();



            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<ISessionDetailRepository, SessionDetailRepository>();
            services.AddScoped<ISessionDetailService, SessionDetailService>();


            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceService,ExperienceService>();

            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<IComplaintService, ComplaintService>();


            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IScheduleService, ScheduleService>();

            services.AddScoped<IDietRepository, DietRepository>();
            services.AddScoped<IDietService, DietService>();

            services.AddScoped<IProgressRepository, ProgressRepository>();
            services.AddScoped<IProgressService, ProgressService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddAutoMapper(typeof(Startup));

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCustomSwagger();

        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCustomSwagger();
        }
    }
}
