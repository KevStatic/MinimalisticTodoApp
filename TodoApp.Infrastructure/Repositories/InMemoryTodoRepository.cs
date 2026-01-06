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

    public void Remove(TodoItem item)
    {
        _todos.Remove(item);
    }
}
