using Microsoft.AspNetCore.SignalR;

namespace Web_Admin_Client.HubsUpdate
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
