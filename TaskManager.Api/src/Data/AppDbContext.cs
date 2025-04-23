

using Microsoft.EntityFrameworkCore;
using tdd.task.manager.Models;
namespace tdd.task.manager.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaskItemModel> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Additional entity configurations can be added here if needed.
    }
}