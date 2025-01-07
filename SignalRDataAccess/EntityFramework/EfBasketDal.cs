using SignalR.EntityLayer.Entities;
using SignalRDataAccess.Abstract;
using SignalRDataAccess.Concrete;
using SignalRDataAccess.Repositories;

namespace SignalRDataAccess.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.MenuTableId == id).ToList();
            return values;
        }
    }
}
