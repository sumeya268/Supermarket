namespace Supermarket.core
{
    public class Sale
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        public SaleItem[] Items { get; set; } = new SaleItem[50];
        public int ItemCount { get; set; } = 0;

        public void AddItem(SaleItem item)
        {
            Items[ItemCount++] = item;
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            for (int i = 0; i < ItemCount; i++)
            {
                total += Items[i].LineTotal;
            }

            return total;
        }
    }
}
