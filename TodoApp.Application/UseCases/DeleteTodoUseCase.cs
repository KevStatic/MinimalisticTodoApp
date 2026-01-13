using TodoApp.Application.Common;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.UseCases;

public sealed class DeleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // Toggle the completion status of a Todo item by its ID
    public async Task<Result> ExecuteAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo == null)
            return Result.Fail("Todo not found");

        _todoRepository.Remove(todo);
        await _todoRepository.SaveChangesAsync(); // 🔥 REQUIRED

        return Result.Ok();
    }



}
