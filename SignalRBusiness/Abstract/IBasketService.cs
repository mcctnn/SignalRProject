using SignalR.EntityLayer.Entities;

namespace SignalRBusiness.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}
