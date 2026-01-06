using System;
using System.Collections.Generic;
using System.Text;

using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories;

public class EfTodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public EfTodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<TodoItem> GetAll()
    {
        return _context.Todos.ToList();
    }

    public TodoItem? GetById(int id)
    {
        return _context.Todos.FirstOrDefault(t => t.Id == id);
    }

    public void Add(TodoItem item)
    {
        _context.Todos.Add(item);
        _context.SaveChanges();
    }

    public void Update(TodoItem item)
    {
        _context.Todos.Update(item);
        _context.SaveChanges();
    }

    public void Remove(TodoItem item)
    {
        _context.Todos.Remove(item);
        _context.SaveChanges();
    }
}
