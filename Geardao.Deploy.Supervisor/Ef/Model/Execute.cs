using System.ComponentModel.DataAnnotations;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public class Execute
    {
        [Key]
        public int Id { get; set; }

        public Worker Worker { get; set; }
        
        public Task Task { get; set; }

        public int ExecuteTime { get; set; }

        public int Timeout { get; set; }
        
        public int Status { get; set; }
        
        public string ReturnLog { get; set; }
        
    }
}