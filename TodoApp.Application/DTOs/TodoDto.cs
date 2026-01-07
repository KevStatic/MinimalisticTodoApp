using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.DTOs;

public class TodoDto
{
    // Unique identifier for the todo item
    public int Id { get; init; }
    // Title or description of the todo item
    public string Title { get; set; } = string.Empty;
    // Indicates whether the todo item is completed
    public bool IsCompleted { get; init; }
}
