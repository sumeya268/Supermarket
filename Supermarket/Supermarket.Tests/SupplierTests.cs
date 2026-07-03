using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.core;

namespace Supermarket.Tests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod]
        public void AddSupplier_ShouldIncreaseCount()
        {
            var list = new SupplierList();
            list.Add(new Supplier { Id = 1, Name = "FreshFoods", ContactNumber = "123", Email = "a@b.com" });

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RemoveSupplier_ShouldDecreaseCount()
        {
            var list = new SupplierList();
            list.Add(new Supplier { Id = 1, Name = "FreshFoods", ContactNumber = "123", Email = "a@b.com" });

            bool removed = list.Remove(1);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void UpdateSupplier_ShouldChangeValues()
        {
            var list = new SupplierList();
            list.Add(new Supplier { Id = 1, Name = "FreshFoods", ContactNumber = "123", Email = "a@b.com" });

            list.Update(new Supplier { Id = 1, Name = "NewFoods", ContactNumber = "999", Email = "new@b.com" });

            var updated = list.LinearSearchById(1);

            Assert.AreEqual("NewFoods", updated.Name);
            Assert.AreEqual("999", updated.ContactNumber);
            Assert.AreEqual("new@b.com", updated.Email);
        }
    }
}
