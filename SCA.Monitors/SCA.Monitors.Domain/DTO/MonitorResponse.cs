using System;
using System.Collections.Generic;
using SCA.Monitors.Domain.Entities;
using SCA.Monitors.Domain.Enum;

namespace SCA.Monitors.Domain.DTO
{
    public class MonitorResponse
    {
        public List<Monitor> Monitors { get; set; }
        public StatusEnum Status { get; set; }
        public string Message { get; set; }
    }
}
