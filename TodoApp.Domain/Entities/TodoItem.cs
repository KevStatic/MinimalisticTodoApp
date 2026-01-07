using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Exceptions;

namespace TodoApp.Domain.Entities;

public class TodoItem
{
    // Unique identifier for the todo item
    public int Id { get; private set; }

    // Title or description of the todo item
    public string Title { get; private set; } = string.Empty;

    // Indicates whether the todo item is completed
    public bool IsCompleted { get; private set; }

    // Indicates whether the todo item is deleted
    public bool IsDeleted { get; private set; }

    // Timestamp when the todo item was created
    public DateTime CreatedAt { get; private set; }

    // Timestamp when the todo item was completed
    public DateTime? CompletedAt { get; private set; }

    // Timestamp when the todo item was deleted
    public DateTime? DeletedAt { get; private set; }

    // Private parameterless constructor for ORM or serialization purposes
    private TodoItem() { } // For EF Core or serialization

    // Constructor to initialize a new todo item
    public TodoItem(string title)
    {
        Title = title;
        CreatedAt = DateTime.UtcNow;
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
        CompletedAt = IsCompleted ? DateTime.UtcNow : null;
    }

    // Method to mark the todo item as deleted
    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }

    // Method to update the title of the todo item
    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Todo title cannot be empty");

        if (title.Length > 200)
            throw new DomainException("Todo title cannot exceed 200 characters");

        Title = title.Trim();
    }
}
