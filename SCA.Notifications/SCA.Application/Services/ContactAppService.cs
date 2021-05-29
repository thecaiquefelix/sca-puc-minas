using System;
using System.Threading.Tasks;
using SCA.Notifications.Application.Interfaces;
using SCA.Notifications.Domain.Entities;
using SCA.Notifications.Domain.Interfaces.Repository;

namespace SCA.Notifications.Application.Services
{
    public class ContactAppService : IContactAppService
    {
        private readonly IContactRepository _contactRepository;

        public ContactAppService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Result> DeleteAsync(string phone)
        {
            try
            {
                await _contactRepository.DeleteAsync(phone);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result("Erro ao deletar contato");
            }
        }

        public async Task<Result> InsertAsync(Contact contact)
        {
            try
            {
                await _contactRepository.InsertAsync(contact);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result("Erro ao inserir contato");
            }
        }
    }
}
