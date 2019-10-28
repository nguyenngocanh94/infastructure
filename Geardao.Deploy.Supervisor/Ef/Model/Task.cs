﻿using System;
using System.Collections.Generic;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Timeout { get; set; }
        public long? Executetime { get; set; }
        public long? Retrytime { get; set; }
        public long? Status { get; set; }
        public string Starttime { get; set; }
        public string Createtime { get; set; }
        public ICollection<Execute> Executes { get; set; }
    }
}
