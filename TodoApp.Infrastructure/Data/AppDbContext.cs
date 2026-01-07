using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasQueryFilter(t => !t.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }
}