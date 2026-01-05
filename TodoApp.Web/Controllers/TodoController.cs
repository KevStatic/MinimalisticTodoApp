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
    public IActionResult Index()
    {
        var todos = _todoService.GetAllTodos();
        return View(todos);
    }

    [HttpPost]
    public IActionResult Create(string title)
    {
        _todoService.CreateTodo(title);
        return RedirectToAction("Index");
    }
}
