using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces;

public interface ITodoRepository
{
    IReadOnlyList<Entities.TodoItem> GetAll();
    void Add(TodoItem item);
}
