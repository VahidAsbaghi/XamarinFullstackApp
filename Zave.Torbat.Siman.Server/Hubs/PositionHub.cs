using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Zave.Torbat.Siman.Server.Hubs
{
    public class PositionHub:Hub
    {
        private string _connectionId = "";
        
        public override Task OnConnectedAsync()
        {
            _connectionId = Context.ConnectionId;
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connectionId = "";
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SetPositionFromServer(float x, float y)
        {
            await Clients.Client(_connectionId).SendAsync("ReceiveNewPosition", x, y);
        }
    }
}
