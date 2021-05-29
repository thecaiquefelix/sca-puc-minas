using System.Threading.Tasks;
using Dapper;
using Dommel;
using SCA.Notifications.Domain.Entities;
using SCA.Notifications.Domain.Interfaces.Factory;
using SCA.Notifications.Domain.Interfaces.Repository;

namespace SCA.Notifications.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbProviderFactory _dbProviderFactory;

        public ContactRepository(IDbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        public async Task DeleteAsync(string phone)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            const string script = @"DELETE [DatabaseSCA].[dbo].[Notifications]
                                    WHERE Phone = @Phone";

            await connection.ExecuteAsync(script, new { Phone = phone });
        }

        public async Task InsertAsync(Contact contact)
        {
            var connection = _dbProviderFactory.CreateScopedConnection();

            await connection.InsertAsync(contact);
        }
    }
}
