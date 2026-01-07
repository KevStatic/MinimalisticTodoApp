using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Services;
using Xunit;

public class TodoServiceTests
{
    [Fact]
    public async Task CreateTodo_WithEmptyTitle_ReturnsFailure()
    {
        var repo = new FakeTodoRepository();
        var service = new TodoService(repo);

        var result = await service.CreateTodoAsync("");

        Assert.False(result.Success);
    }

    [Fact]
    public async Task CreateTodo_WithValidTitle_AddsTodo()
    {
        var repo = new FakeTodoRepository();
        var service = new TodoService(repo);

        var result = await service.CreateTodoAsync("Learn unit testing");
        var todos = await repo.GetAllAsync();

        Assert.True(result.Success);
        Assert.Single(todos);
    }

    [Fact]
    public async Task ToggleComplete_TogglesTodoState()
    {
        var repo = new FakeTodoRepository();
        var service = new TodoService(repo);

        await service.CreateTodoAsync("Test toggle");
        var todo = (await repo.GetAllAsync()).First();

        await service.ToggleCompleteTodoAsync(todo.Id);

        Assert.True(todo.IsCompleted);
    }

    [Fact]
    public async Task DeleteTodo_SoftDeletesTodo()
    {
        var repo = new FakeTodoRepository();
        var service = new TodoService(repo);

        await service.CreateTodoAsync("Delete me");
        var todo = (await repo.GetAllAsync()).First();

        await service.DeleteTodoAsync(todo.Id);

        var todosAfterDelete = await repo.GetAllAsync();

        Assert.True(todo.IsDeleted);
        Assert.Empty(todosAfterDelete);
    }
}
