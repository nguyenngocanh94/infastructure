﻿using System;
using System.Collections.Generic;

namespace Geardao.Deploy.Supervisor.Ef.Model
{
    public partial class Execute
    {
        public long Id { get; set; }
        public Task Task { get; set; }
        public Worker Worker { get; set; }
        public long? Executetime { get; set; }
        public long? Timeout { get; set; }
        public long? Status { get; set; }
        public string Returnlog { get; set; }
    }
}
