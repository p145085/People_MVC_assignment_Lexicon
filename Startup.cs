using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;
using Microsoft.Extensions.Options;

namespace People_MVC_assignment_Lexicon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {// Step 5
            services.AddDbContext<PeopleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<PeopleDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;

            });

            // Step 6
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleRepo, DatabasePersonRepo>();// IoC & DI
            services.AddScoped<IPeopleService, PeopleService>();// IoC & DI

            services.AddScoped<ICityRepo, DatabaseCityRepo>();// IoC & DI
            services.AddScoped<ICityService, CityService>();// IoC & DI

            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();// IoC & DI
            services.AddScoped<ICountryService, CountryService>();// IoC & DI

            services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();// IoC & DI
            services.AddScoped<ILanguageService, LanguageService>();// IoC & DI

            //services.AddControllersWithViews(); //Will be used later maybe

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("*");// replace "*" with the domain or adress from were you will make request from "http://www.my-domain.com"
                                  });
            });

            //services.AddMvc().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // for the static files like jsvascript css and more

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "People API"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
