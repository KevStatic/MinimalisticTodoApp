using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Infrastructure.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _todos = new();

    public IReadOnlyList<TodoItem> GetAll()
    {
        return _todos;
    }

    public TodoItem? GetById(int id)
    {
        return _todos.FirstOrDefault(t => t.Id == id);
    }

    public void Add(TodoItem item)
    {
        _todos.Add(item);
    }

    public void Update(TodoItem item)
    {
        // Nothing required for in-memory
    }

    public Task<IReadOnlyList<TodoItem>> GetAllAsync()
    {
        return Task.FromResult((IReadOnlyList<TodoItem>)_todos);
    }

    public Task<TodoItem?> GetByIdAsync(int id)
    {
        return Task.FromResult(GetById(id));
    }

    public Task AddAsync(TodoItem todo)
    {
        Add(todo);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TodoItem todo)
    {
        Update(todo);
        return Task.CompletedTask;
    }

    public void Remove(TodoItem todo)
    {
        _todos.Remove(todo);
    }

    public Task SaveChangesAsync()
    {
        // In-memory repo doesn't persist, so just return completed task
        return Task.CompletedTask;
    }

}
