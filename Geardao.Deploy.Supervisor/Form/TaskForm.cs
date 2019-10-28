using System.ComponentModel.DataAnnotations;

namespace Geardao.Deploy.Supervisor.Form
{
    public class TaskForm : BaseForm
    {
        [Required]
        public string TaskName { get; set; }
        
        [Required]
        public string TaskId { get; set; }
        
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}