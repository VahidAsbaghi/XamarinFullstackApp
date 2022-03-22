using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public class PushNotifyService : IPushNotifyService
    {
        private const string BaseAddress = @"http://10.0.2.2:59285/";
        public void CreateHubConnection()
        {
            try
            {
                var hubConnection = new HubConnectionBuilder().WithUrl(BaseAddress + "positionHub");
                var hb1=hubConnection.Build();

                //..WithUrl("https://signalrcoreserver.azurewebsites.net/movehub").Build();
                hb1.On<float, float>("ReceiveNewPosition", ReceiveNewPositionHandler);
                var id = hb1.ConnectionId;
                hb1.StartAsync();
            }
            catch (Exception e)
            {
                var ee = e;
            }
            
        }

        private void ReceiveNewPositionHandler(float arg1, float arg2)
        {
            throw new NotImplementedException();
        }
    }
}
