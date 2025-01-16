using SignalR.EntityLayer.Entities;


namespace SignalRBusiness.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
    }
}
