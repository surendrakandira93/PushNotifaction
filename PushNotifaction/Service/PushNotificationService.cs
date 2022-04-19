using PushNotifaction.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PushNotifaction.Service
{
    public class PushNotificationService: IPushNotificationService
    {
        public async Task<bool> PushNotifications(PushNotificationItemDto item)
        {
            string fireBaseApiUrl = "https://fcm.googleapis.com/fcm/send";
            var result = string.Empty;
            using (var httpClient = new HttpClient())
            {
                string serverKey = "AAAAmSEDKT0:APA91bGs9vDj_a-AFXd8CRCQZvu90SW0WWigTJYDBTL1kaZXemhNMYdmXy44SMLw1U90_atxyD66Wk9vCZ5n9eewVUOUrdAYiRX9UiIMiCbRiAn5YRgRmdjE2jpSG-QznCjqlUFkeEMK";
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={serverKey}");
                PushNotificationRequestDto requestModel = new PushNotificationRequestDto()
                {
                    Notification = new NotificationsDto()
                    {
                        Body = item.Description,
                        Title = item.Text,
                        click_action = item.click_action,
                        custom_data = item.custom_data
                    },
                    To = item.Token
                };

                var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore // ignore null values
                });

                StringContent content = new StringContent(JsonConvert.SerializeObject(requestModel, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore // ignore null values
                }), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(fireBaseApiUrl, content))
                {
                    try
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(apiResponse))
                        {
                            result = apiResponse;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            };
            return true;
        }
    }
}
