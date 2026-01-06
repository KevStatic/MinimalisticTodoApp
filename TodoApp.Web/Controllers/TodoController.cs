using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;

namespace TodoApp.Web.Controllers;

public class TodoController : Controller
{
    // Service to manage todo items
    private readonly TodoService _todoService;

    // Constructor injection of the TodoService
    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    // Index action to display all todo items
    public IActionResult Index()
    {
        var todos = _todoService.GetAllTodos();
        return View(todos);
    }

    // Create action to add a new todo item
    [HttpPost]
    public IActionResult Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            ModelState.AddModelError("Title", "Title cannot be empty");
            return RedirectToAction(nameof(Index));
        }
        _todoService.CreateTodo(title);
        return RedirectToAction("Index");
    }

    // Completed action to mark a todo item as completed
    [HttpPost]
    public IActionResult Complete(int id)
    {
        _todoService.ToggleCompleteTodo(id);
        return RedirectToAction(nameof(Index));
    }

    // Make it so that when the user again clicks on the completed todo item, it marks it as not completed
    [HttpPost]
    public IActionResult ToggleComplete(int id)
    {
        _todoService.ToggleCompleteTodo(id);
        return RedirectToAction(nameof(Index));
    }

    // Delete action to remove a todo item
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _todoService.DeleteTodo(id);
        return RedirectToAction(nameof(Index));
    }

    

}
