namespace Supermarket.core
{
    public class SupplierList
    {
        private Supplier[] items = new Supplier[100];
        private int count = 0;

        public int Count => count;

        public void Add(Supplier supplier)
        {
            items[count++] = supplier;
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == id)
                {
                    items[i] = items[count - 1];
                    count--;
                    return true;
                }
            }
            return false;
        }

        public bool Update(Supplier supplier)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == supplier.Id)
                {
                    items[i].Name = supplier.Name;
                    items[i].ContactNumber = supplier.ContactNumber;
                    items[i].Email = supplier.Email;
                    return true;
                }
            }
            return false;
        }

        public Supplier GetAt(int index)
        {
            return items[index];
        }

        public Supplier LinearSearchById(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == id)
                    return items[i];
            }
            return null;
        }

        public Supplier LinearSearchByName(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Name == name)
                    return items[i];
            }
            return null;
        }
    }
}
