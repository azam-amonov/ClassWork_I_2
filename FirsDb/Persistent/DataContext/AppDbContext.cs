using FirsDb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirsDb.Persistent.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=MyFirstDbApp; Username=postgres; Password=qwerty");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();
    }
}