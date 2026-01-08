using System.ComponentModel.DataAnnotations;

public class CreateTodoViewModel
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
}
