using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Notifications.Domain.Entities;

namespace SCA.Notifications.Domain.Interfaces.Repository
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllAsync();
        Task<Notification> GetById(int id);
        Task InsertAsync(Notification notification);
    }
}
