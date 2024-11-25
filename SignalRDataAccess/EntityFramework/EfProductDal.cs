using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context=new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context=new SignalRContext();
            return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(c=>c.CategoryName=="İçecek").Select(y=>y.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameBurger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(c => c.CategoryName == "Burger").Select(y => y.CategoryId).FirstOrDefault())).Count();
        }
    }
}
