using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.core
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }

    }
}

