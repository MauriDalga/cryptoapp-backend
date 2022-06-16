using CorePush.Google;
using Microsoft.Extensions.Options;
using Model.Write;
using ServicesInterface;
using System.Net.Http.Headers;
using static Model.Write.GoogleNotification;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly FcmNotificationSetting _fcmNotificationSetting;

        public NotificationService(IOptions<FcmNotificationSetting> settings)
        {
            _fcmNotificationSetting = settings.Value;
        }

        public async Task SendNotification(string deviceToken, string body)
        {
            try
            {
                FcmSettings settings = new()
                {
                    SenderId = _fcmNotificationSetting.SenderId,
                    ServerKey = _fcmNotificationSetting.ServerKey
                };

                HttpClient httpClient = new();

                string authorizationKey = string.Format("key={0}", settings.ServerKey);

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataPayload dataPayload = new()
                {
                    Title = "¡Transacción Recibida!",
                    Body = body
                };

                GoogleNotification notification = new()
                {
                    Notification = dataPayload
                };

                var fcm = new FcmSender(settings, httpClient);
                var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                if (!fcmSendResponse.IsSuccess())
                {
                    throw new Exception(fcmSendResponse.Results[0].Error);
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
