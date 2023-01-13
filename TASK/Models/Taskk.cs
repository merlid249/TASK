using System.ComponentModel.DataAnnotations;

namespace TASK.Models
{
    public class Taskk
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "DeadLine is required")]
        public DateTime? DeadLine { get; set; }
    }
}
