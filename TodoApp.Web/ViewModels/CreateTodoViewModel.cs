using System.ComponentModel.DataAnnotations;

public class CreateTodoViewModel
{
    [Required]
    [MaxLength(200)]
    public required string Title { get; set; }
}
