using System.ComponentModel.DataAnnotations;

namespace Geardao.Deploy.Supervisor.Form
{
    public class AddWorkerForm : BaseForm
    {
        [Required]
        public string Ip { get; set; }
        [Required]
        public string Password { get; set; }
        public int MaxInstanceInPool { get; set; }
        public int Weight { get; set; }
        [Required]
        public string  UserName { get; set; }
    }
}