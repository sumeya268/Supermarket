using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.core;

namespace Supermarket.Tests
{
    [TestClass]
    public class SalesTests
    {
        [TestMethod]
        public void AddSale_ShouldIncreaseCount()
        {
            var list = new SaleList();
            list.Add(new Sale { Id = 1, CustomerName = "John" });

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void AddSaleItem_ShouldIncreaseItemCount()
        {
            var sale = new Sale { Id = 1, CustomerName = "John" };

            sale.AddItem(new SaleItem { Id = 1, ProductId = 10, Quantity = 2, LineTotal = 5 });

            Assert.AreEqual(1, sale.ItemCount);
        }

        [TestMethod]
        public void GetTotal_ShouldReturnCorrectSum()
        {
            var sale = new Sale { Id = 1, CustomerName = "John" };

            sale.AddItem(new SaleItem { Id = 1, ProductId = 10, Quantity = 2, LineTotal = 5 });
            sale.AddItem(new SaleItem { Id = 2, ProductId = 11, Quantity = 1, LineTotal = 3 });

            decimal total = sale.GetTotal();

            Assert.AreEqual(8, total);
        }
    }
}
