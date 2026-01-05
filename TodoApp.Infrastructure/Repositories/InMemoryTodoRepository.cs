using System;
using System.Collections.Generic;
using System.Text;
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

    public void Add(TodoItem item)
    {
        _todos.Add(item);
    }
}
