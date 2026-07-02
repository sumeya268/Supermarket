namespace Supermarket.core
{
    public class CategoryList
    {
        private Category[] items = new Category[100];
        private int count = 0;

        public int Count => count;

        public void Add(Category category)
        {
            items[count++] = category;
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

        public bool Update(Category category)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == category.Id)
                {
                    items[i].Name = category.Name;
                    return true;
                }
            }
            return false;
        }

        public Category GetAt(int index)
        {
            return items[index];
        }

        public Category LinearSearchById(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Id == id)
                    return items[i];
            }
            return null;
        }

        public Category LinearSearchByName(string name)
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
