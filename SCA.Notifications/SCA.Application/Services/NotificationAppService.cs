using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCA.Notifications.Application.Interfaces;
using SCA.Notifications.Domain.Entities;
using SCA.Notifications.Domain.Interfaces.Repository;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SCA.Notifications.Application.Services
{
    public class NotificationAppService : INotificationAppService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationAppService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Result<List<Notification>>> GetAllAsync()
        {
            try
            {
                var notifications = await _notificationRepository.GetAllAsync();

                return new Result<List<Notification>>(notifications);
            }
            catch (Exception ex)
            {
                return new Result<List<Notification>>(null, "Erro ao consultar as notificacoes");
            }
        }

        public async Task<Result<Notification>> GetById(int id)
        {
            try
            {
                var notification = await _notificationRepository.GetById(id);

                return new Result<Notification>(notification);
            }
            catch (Exception ex)
            {
                return new Result<Notification>(null, "Erro ao consultar notificacao pelo identificador");
            }
        }

        public async Task<Result> SendAsync(int damId, string message)
        {
            try
            {
                var notification = new Notification
                {
                    DamId = damId,
                    Message = message,
                    Date = DateTime.Now
                };

                string accountSid = "AC8704b0d533d5f618957f1dc1e21b7e87";
                string authToken = "f0ff8707c095170ce839226916e0d8e9";


                TwilioClient.Init(accountSid, authToken);

                var messageResource = MessageResource.Create(
                    body: notification.Message,
                    from: new Twilio.Types.PhoneNumber("+14432513359"),
                    to: new Twilio.Types.PhoneNumber("+5511989030338")
                );

                await _notificationRepository.InsertAsync(notification);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result<Notification>(null, "Erro ao inserir a notificacao");
            }
        }
    }
}
