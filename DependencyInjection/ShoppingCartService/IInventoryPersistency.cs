﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartService
{
    public interface IInventoryPersistency
    {
        Product GetProductById(string id);
    }
}
