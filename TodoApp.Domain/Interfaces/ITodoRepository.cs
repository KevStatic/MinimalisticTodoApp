using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces;

public interface ITodoRepository
{
    IReadOnlyList<Entities.TodoItem> GetAll();

    TodoItem? GetById(int id);

    void Add(TodoItem item);

    void Update(TodoItem item);

    void Remove(TodoItem item);
}
