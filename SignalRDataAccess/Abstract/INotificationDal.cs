using SignalR.EntityLayer.Entities;

namespace SignalRDataAccess.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
    }
}
