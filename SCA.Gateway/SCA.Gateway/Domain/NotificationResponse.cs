using System;
namespace SCA.Gateway.Domain
{
    public class NotificationResponse
    {
        public int DamId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
