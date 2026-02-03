using IMSIdentity.Data;
using IMSIdentity.Hubs;
using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace IMSIdentity.Models.Repositories
{
    public class AlertRepository: IAlertRepository
    {
        private readonly MyAppDBContext _context;
        private readonly IHubContext<AlertHub> _hubContext;

        public AlertRepository(MyAppDBContext context, IHubContext<AlertHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task CreateAndBroadcastAsync(string title, string message, string iconClass)
        {
            var alert = new Alert
            {
                Title = title,
                Message = message,
                IconClass = iconClass,
                CreatedAt = DateTime.Now
            };

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveAlert", title, message, iconClass);
        }
    }
}
