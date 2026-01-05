using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Services;

public class TodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public IReadOnlyList<TodoItem> GetAllTodos()
    {
        return _todoRepository.GetAll();
    }

    public void CreateTodo(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty");

        var id = GenerateId();
        var todo = new TodoItem(id, title);

        _todoRepository.Add(todo);
    }
    private int GenerateId()
    {
        return _todoRepository.GetAll().Count + 1;
    }
}
