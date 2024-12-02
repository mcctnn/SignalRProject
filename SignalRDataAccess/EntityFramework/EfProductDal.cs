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

        public decimal ProductPriceAvg()
        {
            using var context=new SignalRContext();
            return context.Products.Average(x=>x.Price);
        }

        public string ProductNameByMaxPrice()
        {
            using var context=new SignalRContext();
            var maxPrice = context.Products.Max(x => x.Price);

            
            return context.Products
                          .Where(x => x.Price == maxPrice)
                          .Select(x => x.ProductName)
                          .SingleOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            var minPrice = context.Products.Min(x => x.Price);


            return context.Products
                          .Where(x => x.Price == minPrice)
                          .Select(x => x.ProductName)
                          .SingleOrDefault();
        }

        public decimal ProductPriceAvgByHamburger()
        {
            using var context= new SignalRContext();
            return context.Products.Where(x => x.CategoryId ==
            (context.Categories.Where(y => y.CategoryName == "Burger")
            .Select(z => z.CategoryId).FirstOrDefault())).Average(a => a.Price);
        }
    }
}
