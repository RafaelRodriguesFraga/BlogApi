using Blog.Domain.Notifications;

namespace Blog.Application.Services.Base
{
    public class BaseServiceApplication : IBaseServiceApplication
    {
        protected readonly NotificationContext _notificationContext;

        public BaseServiceApplication(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }
    }
}
