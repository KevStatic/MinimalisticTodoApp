using System.ComponentModel.DataAnnotations;

namespace TodoApp.Web.ViewModels;

public class EditTodoViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
}
