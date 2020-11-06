using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twitter.Domain.Models;
using Twitter.Domain.Repositories;
using Twitter.Domain.Services;
using Twitter.RealizationAndContext;
using Twitter.RealizationAndContext.Repositories;
using Twitter.Resources;
using Twitter.Services;

namespace Twitter
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
            services.AddMvc(options =>{
                options.Filters.Add(new ConsumesAttribute("application/json"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //DATABASE
            var connection = @"data source=DESKTOP-JQDJF79\SQLEXPRESS;initial catalog=Twitter;integrated security=True;MultipleActiveResultSets=True";
            services.AddEntityFrameworkSqlServer().AddDbContext<TwitterDbContext>(options => options.UseSqlServer(connection));

            //mapp
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors();

            
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());    
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
