using ListingTodos.Entities;
using ListingTodos.Models;
using ListingTodos.Repositories;
using ListingTodos.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ListingTodos
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TodoContext>(options => 
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=todoDB; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"));
            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<TodoContext>()
            //    .AddTokenProvider();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options => 
            //    {
            //        options.AccessDeniedPath = "/Errors/ErrorForbidden";
            //        options.LoginPath = "/Errors/ErrorNotLoggedIn";
            //    })
                /*.AddGoogle()*/;

            //services.AddAuthorization(options => 
            //options.AddPolicy("MustBeAdmin", p => p.RequireAuthenticatedUser().RequireRole("admin")));

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
            //else
            //{
                //app.UseExceptionHandler("/Errors");
                //app.UseStatusCodePagesWithReExecute("Errors/Error/{0}");
            //}

            app.UseStaticFiles();

            //app.UseAuthentication();

            app.UseMvc();
        }
    }
}
