using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.core;

namespace Supermarket.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void AddProduct_ShouldIncreaseCount()
        {
            var list = new ProductList();
            list.Add(new Product { Id = 1, Title = "Milk", Barcode = "111" });

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RemoveProduct_ShouldDecreaseCount()
        {
            var list = new ProductList();
            list.Add(new Product { Id = 1, Title = "Milk", Barcode = "111" });

            bool removed = list.Remove(1);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void UpdateProduct_ShouldChangeValues()
        {
            var list = new ProductList();
            list.Add(new Product { Id = 1, Title = "Milk", Barcode = "111" });

            list.Update(new Product { Id = 1, Title = "Bread", Barcode = "222" });

            var updated = list.LinearSearchById(1);

            Assert.AreEqual("Bread", updated.Title);
            Assert.AreEqual("222", updated.Barcode);
        }

        [TestMethod]
        public void SearchProduct_ShouldReturnCorrectProduct()
        {
            var list = new ProductList();
            list.Add(new Product { Id = 1, Title = "Milk", Barcode = "111" });

            var result = list.LinearSearchByName("Milk");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
