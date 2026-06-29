using Supermarket.core;
using System;

namespace Supermarket.Core
{
    public class ProductList
    {
        private Product[] items;
        private int count;

        public ProductList(int capacity = 10)
        {
            items = new Product[capacity];
            count = 0;
        }

        public int Count => count;

        public void Add(Product product)
        {
            if (count == items.Length)
                Resize();

            items[count] = product;
            count++;
        }

        private void Resize()
        {
            Product[] newArray = new Product[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
                newArray[i] = items[i];

            items = newArray;
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == id)
                {
                    for (int j = i; j < count - 1; j++)
                        items[j] = items[j + 1];

                    count--;
                    return true;
                }
            }
            return false;
        }

        public bool Update(Product updated)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == updated.Id)
                {
                    items[i] = updated;
                    return true;
                }
            }
            return false;
        }

        public Product? LinearSearchByName(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Title.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return items[i];
            }
            return null;
        }

        public void SortByBarcode()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (string.Compare(items[i].Barcode, items[j].Barcode) > 0)
                    {
                        var temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public Product BinarySearchByBarcode(string barcode)
        {
            SortByBarcode();

            int left = 0;
            int right = count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(items[mid].Barcode, barcode);

                if (comparison == 0)
                    return items[mid];

                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }
    }
}
