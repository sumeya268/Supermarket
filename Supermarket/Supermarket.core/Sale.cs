using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.core
{
    public class Sale
    {
        public int Id { get; set;}
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleItem> Items { get; set; } = new();
    }
}
