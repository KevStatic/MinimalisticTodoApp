using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Domain.Entities;

public class TodoItem
{
    // Unique identifier for the todo item
    public int Id { get; private set; }

    // Title or description of the todo item
    public string Title { get; private set; } = string.Empty;

    // Indicates whether the todo item is completed
    public bool IsCompleted { get; private set; }

    // Private parameterless constructor for ORM or serialization purposes
    private TodoItem() { }

    // Constructor to initialize a new todo item
    public TodoItem(int id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
    }

    // Method to mark the todo item as completed
    public void MarkCompleted()
    {
        IsCompleted = true;
    }

    // Method to toggle the completion status
    public void ToggleCompleted()
    {
        IsCompleted = !IsCompleted;
    }
}
