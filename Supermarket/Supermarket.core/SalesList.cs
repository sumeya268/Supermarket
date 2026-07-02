namespace Supermarket.core
{
    public class SaleList
    {
        private Sale[] sales = new Sale[100];
        private int count = 0;

        public int Count => count;

        public void Add(Sale sale)
        {
            sales[count++] = sale;
        }

        public Sale GetAt(int index)
        {
            return sales[index];
        }
    }
}
