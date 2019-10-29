﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;

 namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Execute
    {
        [Key]
        public int Id { get; set; }
        public Task Task { get; set; }
        public Worker Worker { get; set; }
        public int? Executetime { get; set; }
        public int? Timeout { get; set; }
        public int? Status { get; set; }
        public string Returnlog { get; set; }
    }
}
