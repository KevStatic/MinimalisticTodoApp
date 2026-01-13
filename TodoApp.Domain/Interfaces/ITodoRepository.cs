using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces;

public interface ITodoRepository
{
    Task<IReadOnlyList<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);

    Task AddAsync(TodoItem todo);
    Task UpdateAsync(TodoItem todo);

    void Remove(TodoItem todo);
    Task SaveChangesAsync();
}
