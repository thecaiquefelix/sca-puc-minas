using System;
namespace SCA.Notifications.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int DamId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
