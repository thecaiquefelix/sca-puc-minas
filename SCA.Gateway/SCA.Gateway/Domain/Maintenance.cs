using System;
namespace SCA.Gateway.Domain
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public Type Type { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }

    public enum Type
    {
        Preventive,
        Corrective
    }

    public enum Status
    {
        Todo,
        Doing,
        Done
    }
}
