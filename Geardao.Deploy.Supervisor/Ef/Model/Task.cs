using System;
using System.ComponentModel.DataAnnotations;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Timeout { get; set; }

        public int RetryTime { get; set; }

        public int Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime CreateTime { get; set; }
    }
}