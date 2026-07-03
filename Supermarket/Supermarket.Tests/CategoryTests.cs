using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.core;

namespace Supermarket.Tests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void AddCategory_ShouldIncreaseCount()
        {
            var list = new CategoryList();
            list.Add(new Category { Id = 1, Name = "Dairy" });

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RemoveCategory_ShouldDecreaseCount()
        {
            var list = new CategoryList();
            list.Add(new Category { Id = 1, Name = "Dairy" });

            bool removed = list.Remove(1);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void UpdateCategory_ShouldChangeName()
        {
            var list = new CategoryList();
            list.Add(new Category { Id = 1, Name = "Dairy" });

            list.Update(new Category { Id = 1, Name = "Bakery" });

            var updated = list.LinearSearchById(1);

            Assert.AreEqual("Bakery", updated.Name);
        }
    }
}
