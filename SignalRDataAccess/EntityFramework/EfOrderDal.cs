using SignalR.EntityLayer.Entities;
using SignalRDataAccess.Abstract;
using SignalRDataAccess.Concrete;
using SignalRDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccess.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x=>x.Description.Equals("Müşteri masada")).Count();
        }

        public decimal LastOrderPrice()
        {
            using var context= new SignalRContext();
            return context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public int OrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return 0;
        }
    }
}
