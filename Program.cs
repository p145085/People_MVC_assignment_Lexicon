using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;

namespace People_MVC_assignment_Lexicon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PeopleDbContext>(
                options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString(
                    "DefaultConnection"
                    )
                )
            );
            //builder.Services.AddScoped<IPersonRepo, InMemoryPersonRepo>();
            builder.Services.AddScoped<IPeopleRepo, DatabasePersonRepo>();
            builder.Services.AddScoped<IPeopleService, PeopleService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{Id?}");

            app.Run();
        }
    }
}