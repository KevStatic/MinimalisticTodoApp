using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

public class FakeTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _todos = new();

    public Task<IReadOnlyList<TodoItem>> GetAllAsync()
        => Task.FromResult<IReadOnlyList<TodoItem>>(
            _todos.Where(t => !t.IsDeleted).ToList()
        );

    public Task<TodoItem?> GetByIdAsync(int id)
        => Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));

    public Task AddAsync(TodoItem item)
    {
        _todos.Add(item);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TodoItem item)
        => Task.CompletedTask;

    public void Remove(TodoItem todo)
    {
        _todos.Remove(todo);
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}
