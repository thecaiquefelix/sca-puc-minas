using System;
using System.Collections.Generic;

namespace SCA.Gateway.Domain
{
    public class MonitorResponse
    {
        public List<Monitor> Monitors { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
