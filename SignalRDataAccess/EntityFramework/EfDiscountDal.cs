﻿using SignalR.EntityLayer.Entities;
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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }
    }
}