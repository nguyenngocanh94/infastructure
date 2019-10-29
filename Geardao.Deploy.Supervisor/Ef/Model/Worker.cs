﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;

 namespace Geardao.Deploy.Supervisor.Ef.Model
{
    [Serializable]
    public partial class Worker
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Instanceinpool { get; set; }
        public int? Maxinstanceinpool { get; set; }
        public int? Healthy { get; set; }
        
        public int State { get; set; }
        public int Weight { get; set; }
        public ICollection<Execute> Executes { get; set; }
    }
}
