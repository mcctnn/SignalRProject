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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void TAdd(MenuTable entity)=>_menuTableDal.Add(entity);

        public void TDelete(MenuTable entity)=>_menuTableDal.Delete(entity);

        public MenuTable TGetById(int id)=>_menuTableDal.GetById(id);

        public List<MenuTable> TGetListAll()=>_menuTableDal.GetListAll();

        public int TMenuTableCount()=>_menuTableDal.MenuTableCount();

        public void TUpdate(MenuTable entity)=>_menuTableDal.Update(entity);
    }
}
