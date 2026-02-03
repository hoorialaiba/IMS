using Microsoft.AspNetCore.SignalR;

namespace IMSIdentity.Hubs
{
    public class AlertHub: Hub
    {
        public async Task SendMessage(string title, string message, string iconClass)
        {
            await Clients.All.SendAsync("ReceiveAlert", title, message, iconClass);
        }
    }
}
