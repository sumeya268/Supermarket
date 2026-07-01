using Supermarket.core;

class Program
{
    static void WriteColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();

    }

    static ProductList productList = new ProductList();

    static void Main()
    {
        Console.Title = "Supermarket Management System";

        while (true)
        {
            Console.Clear();
            DrawHeader("SUPERMARKET MANAGEMENT SYSTEM");

            WriteColored("1. Add Product", ConsoleColor.DarkYellow);
            WriteColored("2. Remove Product", ConsoleColor.DarkYellow);
            WriteColored("3. Update Product", ConsoleColor.DarkYellow);
            WriteColored("4. Search Product", ConsoleColor.DarkYellow);
            WriteColored("5. List All Products", ConsoleColor.DarkYellow);
            WriteColored("6. Exit", ConsoleColor.DarkRed);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Select an option: ");
            Console.ResetColor();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": RemoveProduct(); break;
                case "3": UpdateProduct(); break;
                case "4": SearchProduct(); break;
                case "5": ListProducts(); break;
                case "6": ExitProgram(); return;
                default:
                    Console.WriteLine("\nInvalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void DrawHeader(string title)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================");
        Console.WriteLine($"                 {title}");
        Console.WriteLine("===============================================\n");
        Console.ResetColor();
    }

    static void AddProduct()
    {
        Console.Clear();
        DrawHeader("ADD PRODUCT");

        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Barcode: ");
        string barcode = Console.ReadLine();

        productList.Add(new Product { Id = id, Title = name, Barcode = barcode });

        Console.WriteLine("\nProduct added successfully!");
        Pause();
    }

    static void RemoveProduct()
    {
        Console.Clear();
        DrawHeader("REMOVE PRODUCT");

        Console.Write("Enter Product ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        bool removed = productList.Remove(id);

        Console.WriteLine(removed
            ? "\nProduct removed successfully!"
            : "\nProduct not found.");

        Pause();
    }

    static void UpdateProduct()
    {
        Console.Clear();
        DrawHeader("UPDATE PRODUCT");

        Console.Write("Enter Product ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter new Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter new Barcode: ");
        string barcode = Console.ReadLine();

        bool updated = productList.Update(new Product { Id = id, Title = name, Barcode = barcode });

        Console.WriteLine(updated
            ? "\nProduct updated successfully!"
            : "\nProduct not found.");

        Pause();
    }

    static void SearchProduct()
    {
        Console.Clear();
        DrawHeader("SEARCH PRODUCT");

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        var product = productList.LinearSearchByName(name);

        if (product != null)
        {
            Console.WriteLine("\nProduct Found:");
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Name: {product.Title}");
            Console.WriteLine($"Barcode: {product.Barcode}");
        }
        else
        {
            Console.WriteLine("\nProduct not found.");
        }

        Pause();
    }

    static void ListProducts()
    {
        Console.Clear();
        DrawHeader("ALL PRODUCTS");

        if (productList.Count == 0)
        {
            Console.WriteLine("No products available.");
        }
        else
        {
            for (int i = 0; i < productList.Count; i++)
            {
                var p = productList.GetAt(i);
                Console.WriteLine($"ID: {p.Id} | Name: {p.Title} | Barcode: {p.Barcode}");
            }
        }

        Pause();
    }

    static void ExitProgram()
    {
        Console.Clear();
        DrawHeader("EXIT");
        Console.WriteLine("Thank you for using the system.");
        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }

    static void Pause()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
