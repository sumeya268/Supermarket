using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Supermarket.core
{
    public class Product
    {
        public int Id { get; set; } // unique id number for each product        
        public string Title { get; set; } 
        public string Brand { get; set; }  
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; } //how many items in stock 
        public DateTime ExpiryOrRestockDate { get; set; }
        
    }
}
