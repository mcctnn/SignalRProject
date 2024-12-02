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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public int TProductCount()=>_productDal.ProductCount();

        public int TProductCountByCategoryNameBurger()=>_productDal.ProductCountByCategoryNameBurger();
        

        public int TProductCountByCategoryNameDrink()=>_productDal.ProductCountByCategoryNameDrink();

        public decimal TProductPriceAvg()=>_productDal.ProductPriceAvg();

        public string TProductNameByMaxPrice()=>_productDal.ProductNameByMaxPrice();
        
        public string TProductNameByMinPrice()=>_productDal.ProductNameByMinPrice();

        public decimal TProductPriceAvgByHamburger() => _productDal.ProductPriceAvgByHamburger();        
    }
}
