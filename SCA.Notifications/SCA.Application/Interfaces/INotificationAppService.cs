using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Notifications.Domain.Entities;

namespace SCA.Notifications.Application.Interfaces
{
    public interface INotificationAppService
    {
        Task<Result<List<Notification>>> GetAllAsync();
        Task<Result<Notification>> GetById(int id);
        Task<Result> SendAsync(int damId, string message);
    }
}
