using TodoApp.Application.Common;
using TodoApp.Application.DTOs;
using TodoApp.Application.UseCases;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Services;

public class TodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly CreateTodoUseCase _createTodo;
    private readonly ToggleTodoUseCase _toggleTodo;
    private readonly DeleteTodoUseCase _deleteTodo;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
        _createTodo = new CreateTodoUseCase(todoRepository);
        _toggleTodo = new ToggleTodoUseCase(todoRepository);
        _deleteTodo = new DeleteTodoUseCase(todoRepository);
    }

    // Query to get all Todo items
    public async Task<IReadOnlyList<TodoDto>> GetAllTodosAsync()
    {
        var todos = await _todoRepository.GetAllAsync();

        return todos.Select(t => new TodoDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        }).ToList();
    }

    // Commands delegate to use cases asynchronously
    public Task<Result> CreateTodoAsync(string title)
    => _createTodo.ExecuteAsync(title);

    public Task<Result> ToggleCompleteTodoAsync(int id)
        => _toggleTodo.ExecuteAsync(id);

    public Task<Result> DeleteTodoAsync(int id)
        => _deleteTodo.ExecuteAsync(id);

}
