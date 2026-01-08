using TodoApp.Application.Common;
using TodoApp.Domain.Interfaces;

public class EditTodoUseCase
{
    private readonly ITodoRepository _repository;

    public EditTodoUseCase(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> ExecuteAsync(int id, string title)
    {
        var todo = await _repository.GetByIdAsync(id);
        if (todo == null)
            return Result.Fail("Todo not found");

        try
        {
            todo.Rename(title);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }

        await _repository.UpdateAsync(todo);
        return Result.Ok();
    }
}
