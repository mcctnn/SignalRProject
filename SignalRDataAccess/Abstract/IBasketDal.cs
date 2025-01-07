using SignalR.EntityLayer.Entities;

namespace SignalRDataAccess.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
