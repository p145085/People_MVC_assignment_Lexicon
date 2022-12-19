using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;

namespace People_MVC_assignment_Lexicon
{
    public class Program
    {
        private static readonly RoleManager<IdentityRole> roleManager;
        private static readonly UserManager<AppUser> userManager;

        private static void CreateDbIfNotExists(IHost app)
        {
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<PeopleDbContext>();
            //        DbInitializer.Initialize(context, roleManager, userManager);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while creating the DB.");
            //    }
            //}
            
        }

        internal class DbInitializer
        {
            internal static async Task Initialize(PeopleDbContext context, UserManager<AppUser> userManager)
            {

                //context.Database.EnsureCreated();//If not using EF migrations
                
                try
                {
                    RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                    var testtest = await roleStore.CreateAsync(new IdentityRole()
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    }); // Skapar en generic roll med sträng 'Admin'.
                } catch (Exception ex) // Fixa problemet med att den hittar en duplicate entry. En slags if-check kanske.
                {
                    Console.WriteLine(ex.Message);
                }

                AppUser minUser2 = await userManager.FindByNameAsync("Populus"); // Sök upp användare 'Populus'.

                try
                {
                    IdentityResult result = await userManager.AddToRoleAsync(minUser2, "Admin"); // Samma some rad 50, duplicate entry. Användare är redan tillagd som Admin.

                    if (result.Succeeded)
                    {
                        Console.WriteLine(minUser2.NickName + " has been added as an Admin.");
                    }
                    else
                    {
                        Console.WriteLine(minUser2.NickName + " could not be added as an Admin.");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Lägg till funnen användare till rollen som betecknas 'Admin'.
                // Note: Tror att användaren successfully blir tillagd som Admin men att problemet att visa länkarna enligt _Layout har ett annat problem till varför de inte syns.

                

                context.Database.Migrate();
            }
        }

        public static async Task Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<PeopleDbContext>()
                    .AddDefaultTokenProviders();

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
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = false;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });

            //

            //

            //builder.Services.AddScoped<IPersonRepo, InMemoryPersonRepo>();
            builder.Services.AddScoped<IPeopleService, PeopleService>();
            builder.Services.AddScoped<IPeopleRepo, DatabasePersonRepo>();

            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepo, DatabaseCityRepo>();

            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<ICountryRepo, DatabaseCountryRepo>();

            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();



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

            // Identity
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Seeding - Custom-class.
            //CreateDbIfNotExists(app);

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                UserManager<AppUser> userManager = services.GetService<UserManager<AppUser>>();
                var context = services.GetRequiredService<PeopleDbContext>();
                await DbInitializer.Initialize(context, userManager);
            }

            app.Run();
        }
    }
}