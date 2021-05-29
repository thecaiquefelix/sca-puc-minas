using System.Threading.Tasks;
using SCA.Notifications.Domain.Entities;

namespace SCA.Notifications.Domain.Interfaces.Repository
{
    public interface IContactRepository
    {
        Task InsertAsync(Contact contact);
        Task DeleteAsync(string phone);
    }
}
