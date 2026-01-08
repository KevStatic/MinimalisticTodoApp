using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;
using TodoApp.Web.ViewModels;

namespace TodoApp.Web.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    // Constructor
    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    // Display the list of Todo items
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var todos = await _todoService.GetAllTodosAsync();
        return View(todos);
    }

    // Add a new Todo item
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTodoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid todo data";
            return RedirectToAction(nameof(Index));
        }

        var result = await _todoService.CreateTodoAsync(model.Title);

        if (!result.Success)
            TempData["Error"] = result.Error;

        return RedirectToAction(nameof(Index));
    }


    // Toggle the completion status of a Todo item
    [HttpPost]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        await _todoService.ToggleCompleteTodoAsync(id);
        return RedirectToAction(nameof(Index));
    }

    // Delete a Todo item
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteTodoAsync(id);
        return RedirectToAction(nameof(Index));
    }

    // Edit a Todo item GET
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var todos = await _todoService.GetAllTodosAsync();
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
            return NotFound();

        var vm = new EditTodoViewModel
        {
            Id = todo.Id,
            Title = todo.Title
        };

        return View(vm);
    }

    // Edit a Todo item POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditTodoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _todoService.EditTodoAsync(model.Id, model.Title);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.Error);
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }




}
