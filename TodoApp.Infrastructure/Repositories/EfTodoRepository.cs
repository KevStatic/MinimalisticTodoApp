using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;
using TodoApp.Infrastructure.Data;

public class EfTodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public EfTodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<TodoItem>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(TodoItem item)
    {
        await _context.Todos.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem item)
    {
        _context.Todos.Update(item);
        await _context.SaveChangesAsync();
    }
}
