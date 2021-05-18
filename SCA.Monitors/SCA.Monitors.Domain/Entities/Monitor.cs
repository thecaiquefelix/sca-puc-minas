using System;
namespace SCA.Monitors.Domain.Entities
{
    public class Monitor
    {
        public int Id { get; set; }
        public int DamId { get; set; }
        public int MetricId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
