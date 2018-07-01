using ListingTodos.Entities;
using ListingTodos.Repositories;
using ListingTodos.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ListingTodos
{
    public class Startup
    {
        //public static object Configuration { get; private set; }

        //var connectionString = Configuration.GetConnectionString("BlogContext");


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TodoContext>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStringTodoDB")));
                 //options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=todoDB; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"));
            services.AddScoped<TodoRepository>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<TodoViewModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
