﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusiness.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
    }
}
