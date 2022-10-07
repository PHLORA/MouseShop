using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Book> Books { get; set; }
    
}