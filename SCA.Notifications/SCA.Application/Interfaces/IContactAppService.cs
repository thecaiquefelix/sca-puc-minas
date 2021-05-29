using System.Threading.Tasks;
using SCA.Notifications.Domain.Entities;

namespace SCA.Notifications.Application.Interfaces
{
    public interface IContactAppService
    {
        Task<Result> InsertAsync(Contact contact);
        Task<Result> DeleteAsync(string phone);
    }
}
