﻿using System;
using System.Collections.Generic;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Worker
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Privatekey { get; set; }
        public long? Instanceinpool { get; set; }
        public long? Maxinstanceinpool { get; set; }
        public long? Healthy { get; set; }
        
        public ICollection<Execute> Executes { get; set; }
    }
}
