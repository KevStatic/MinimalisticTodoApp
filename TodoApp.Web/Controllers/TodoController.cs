using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;

namespace TodoApp.Web.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<IActionResult> Index()
    {
        var todos = await _todoService.GetAllTodosAsync();
        return View(todos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        await _todoService.CreateTodoAsync(title);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        await _todoService.ToggleCompleteTodoAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteTodoAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
