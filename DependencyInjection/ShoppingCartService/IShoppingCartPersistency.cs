﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartService
{
    public interface IShoppingCartPersistency
    {
        ShoppingCart GetShoppingCartById(long id);

        ShoppingCart CreateNewShoppingCart();
    }
}
