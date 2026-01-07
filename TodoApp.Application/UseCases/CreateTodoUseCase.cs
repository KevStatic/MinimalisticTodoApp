using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Application.Common;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;

namespace TodoApp.Application.UseCases;

public class CreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // Asynchronous execution method
    public async Task<Result> ExecuteAsync(string title)
    {
        try
        {
            var todo = new TodoItem(title);
            await _todoRepository.AddAsync(todo);
            return Result.Ok();
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }

}
