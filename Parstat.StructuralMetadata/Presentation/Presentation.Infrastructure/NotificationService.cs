using System.Threading.Tasks;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Notifications.Models;

namespace Presentation.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}