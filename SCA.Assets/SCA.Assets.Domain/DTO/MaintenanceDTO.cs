using System;
using SCA.Assets.Domain.Entities;
using Type = SCA.Assets.Domain.Entities.Type;

namespace SCA.Assets.Domain.DTO
{
    public class MaintenanceDTO
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public Type Type { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
