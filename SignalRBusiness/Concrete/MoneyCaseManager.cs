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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCase;

        public MoneyCaseManager(IMoneyCaseDal moneyCase)
        {
            _moneyCase = moneyCase;
        }

        public void TAdd(MoneyCase entity)=>_moneyCase.Add(entity);

        public void TDelete(MoneyCase entity)=>_moneyCase.Delete(entity);

        public MoneyCase TGetById(int id)=>_moneyCase.GetById(id);
        public List<MoneyCase> TGetListAll()=>_moneyCase.GetListAll();

        public decimal TTotalMoneyCaseAmount()=>_moneyCase.TotalMoneyCaseAmount();

        public void TUpdate(MoneyCase entity)=>_moneyCase.Update(entity);
    }
}
