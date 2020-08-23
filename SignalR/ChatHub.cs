using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string username,string message )
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected",$"{Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnected", $"{Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
