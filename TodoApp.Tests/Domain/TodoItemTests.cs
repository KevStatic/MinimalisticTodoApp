using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;
using Xunit;

public class TodoItemTests
{
    [Fact]
    public void Creating_Todo_With_Empty_Title_Throws()
    {
        Assert.Throws<DomainException>(() => new TodoItem(""));
    }

    [Fact]
    public void Creating_Todo_With_Too_Long_Title_Throws()
    {
        var longTitle = new string('a', 201);
        Assert.Throws<DomainException>(() => new TodoItem(longTitle));
    }

    [Fact]
    public void Creating_Todo_With_Valid_Title_Succeeds()
    {
        var todo = new TodoItem("Valid title");
        Assert.Equal("Valid title", todo.Title);
    }
}
