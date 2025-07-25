using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMS.Shared.Models;

namespace SMS.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<SystemCode> SystemCodes { get; set; }
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Student>()
            .HasIndex(s => s.RegNo)
            .IsUnique();
        
        base.OnModelCreating(builder);
    }
}