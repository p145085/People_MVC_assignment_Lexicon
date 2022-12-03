namespace People_MVC_assignment_Lexicon;

using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models.Basemodels;

public class PeopleDbContext : DbContext
{
    public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
    { }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Person>? People { get; set; }
    public DbSet<Language>? Languages { get; set; }
}
