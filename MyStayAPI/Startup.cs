﻿using Agent;
using Agent.Interface;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface;

namespace MyStayAPI
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyStayAPI")));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IHotelAgent, HotelAgent>();
            services.AddScoped<IUserAgent, UserAgent>();
            services.AddScoped<IHotelRoomAgent, HotelRoomAgent>();
            services.AddScoped<IBookingAgent, BookingAgent>();


            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration.GetConnectionString("RedisConnection");
                option.InstanceName = "master";
            });


            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("MyStaySpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "MyStay API",
                    Version = "1"
                });
                // setupAction.IncludeXmlComments("MyStayAPI.xml");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/MyStaySpecification/swagger.json",
                    "MyStay API");
                setupAction.RoutePrefix = "";

            });


            app.UseMvc();

        }
    }
}
