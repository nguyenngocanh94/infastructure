﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;

 namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Timeout { get; set; }
        public int? Executetime { get; set; }
        public int? Retrytime { get; set; }
        public int? Status { get; set; }
        public string Starttime { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public ICollection<Execute> Executes { get; set; }
    }
}
