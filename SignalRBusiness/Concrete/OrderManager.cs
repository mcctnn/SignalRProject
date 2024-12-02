using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusiness.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)=>_orderDal.Add(entity);

        public void TDelete(Order entity)=>_orderDal.Delete(entity);

        public Order TGetById(int id)=>_orderDal.GetById(id);

        public List<Order> TGetListAll()=>_orderDal.GetListAll();

        public void TUpdate(Order entity)=>_orderDal.Update(entity);
    }
}
