using System.Threading.Tasks;
using Presentation.Application.Notifications.Models;

namespace Presentation.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}