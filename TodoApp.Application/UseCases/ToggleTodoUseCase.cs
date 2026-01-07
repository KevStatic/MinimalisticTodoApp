using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Application.Common;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.UseCases;

public sealed class ToggleTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public ToggleTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // Toggle the completion status of a Todo item by its ID
    public async Task<Result> ExecuteAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo == null)
            return Result.Fail("Todo not found");

        try
        {
            todo.ToggleCompleted();
            await _todoRepository.UpdateAsync(todo);
            return Result.Ok();
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }



}
