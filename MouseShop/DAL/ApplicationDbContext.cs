using Microsoft.EntityFrameworkCore;
using MouseShop.Domain.Models;

namespace MouseShop.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Mouse> Mice { get; set; }
    
}