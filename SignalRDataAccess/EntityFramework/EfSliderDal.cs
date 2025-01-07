using SignalR.EntityLayer.Entities;
using SignalRDataAccess.Abstract;
using SignalRDataAccess.Concrete;
using SignalRDataAccess.Repositories;

namespace SignalRDataAccess.EntityFramework
{
    public class EfSliderDal : GenericRepository<Slider>, ISliderDal
    {
        public EfSliderDal(SignalRContext context) : base(context)
        {
        }
    }
}
