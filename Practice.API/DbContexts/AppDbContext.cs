using Microsoft.EntityFrameworkCore;
using Practice.API.Entities;

namespace Practice.API.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=MyFirstDbApp2; Username=postgres; Password=qwerty");
    }
}