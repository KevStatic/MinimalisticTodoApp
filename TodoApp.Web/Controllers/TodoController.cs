using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;

namespace TodoApp.Web.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    public record UpdateTodoTitleRequest(int Id, string Title);

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

    // Add a new Todo item (form POST)
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

    [HttpPost]
    public async Task<IActionResult> UpdateTitle([FromBody] UpdateTodoTitleRequest request)
    {
        await _todoService.EditTodoAsync(request.Id, request.Title);
        return Ok();
    }

    [HttpPost]
    [Route("api/todo/create")]
    public async Task<IActionResult> CreateApi([FromBody] CreateTodoViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Title))
            return BadRequest();

        var result = await _todoService.CreateTodoAsync(model.Title);

        if (!result.Success)
            return BadRequest(result.Error);

        return Ok(); // ✅ unchanged
    }

    [HttpGet]
    [Route("api/todo/latest")]
    public async Task<IActionResult> GetLatest()
    {
        var todos = await _todoService.GetAllTodosAsync();
        var latest = todos.OrderByDescending(t => t.Id).FirstOrDefault();

        return Ok(latest);
    }

    [HttpDelete]
    [Route("api/todo/{id}")]
    public async Task<IActionResult> DeleteApi(int id)
    {
        var result = await _todoService.DeleteTodoAsync(id);

        if (!result.Success)
            return BadRequest(result.Error);

        return Ok(new { success = true });
    }

}
