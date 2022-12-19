namespace People_MVC_assignment_Lexicon;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models.Basemodels;

public class PeopleDbContext : IdentityDbContext<AppUser>
{
    public PeopleDbContext()
    {
    }

    public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
    { }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Person>? People { get; set; }
    public DbSet<Language>? Languages { get; set; }
    public DbSet<AppUser>? appUsers { get; set; }
}