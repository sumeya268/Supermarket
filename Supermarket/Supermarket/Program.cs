using Supermarket.core;

class Program
{
    static ProductList productList = new ProductList();
    static CategoryList categoryList = new CategoryList();
    static SupplierList supplierList = new SupplierList();
    static SaleList salelist = new SaleList();

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
            WriteColored("6. Category Management", ConsoleColor.DarkYellow);
            WriteColored("7. Supplier Management", ConsoleColor.DarkYellow);
            WriteColored("8. Sales Management", ConsoleColor.DarkYellow);
            WriteColored("9. Exit", ConsoleColor.DarkRed);

            Console.WriteLine();
            WriteColoredInline("Select an option: ", ConsoleColor.DarkGreen);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": RemoveProduct(); break;
                case "3": UpdateProduct(); break;
                case "4": SearchProduct(); break;
                case "5": ListProducts(); break;
                case "6": CategoryMenu(); break;
                case "7": SupplierMenu(); break;
                case "8": SalesMenu(); break;
                case "9": Exit(); return;

                default:
                    WriteColored("\nInvalid option. Press any key to continue...", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
    }

    // ------------------ UI Helpers ------------------

    static void WriteColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    static void WriteColoredInline(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    static void DrawHeader(string title)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================================");
        Console.WriteLine($"                     {title.ToUpper()}");
        Console.WriteLine("===============================================================\n");
        Console.ResetColor();
    }

    static int ReadInt(string label)
    {
        WriteColoredInline(label, ConsoleColor.DarkYellow);

        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            WriteColored("Invalid number. Try again: ", ConsoleColor.Red);
        }

        return value;
    }

    static string ReadString(string label)
    {
        WriteColoredInline(label, ConsoleColor.DarkYellow);

        string input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            WriteColored("Input cannot be empty. Try again: ", ConsoleColor.Red);
            input = Console.ReadLine();
        }

        return input;
    }

    static void Pause()
    {
        WriteColored("\nPress any key to return to the menu...", ConsoleColor.DarkGray);
        Console.ReadKey();
    }

    // ------------------ Product Management ------------------

    static void AddProduct()
    {
        DrawHeader("ADD PRODUCT");
        WriteColored("=== Add Product ===\n", ConsoleColor.Blue);

        int id = ReadInt("Enter Product ID: ");

        var existingId = productList.LinearSearchById(id);
        if (existingId != null)
        {
            WriteColored("\nA product with this ID already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        string name = ReadString("Enter Product Name: ");

        var existingName = productList.LinearSearchByName(name);
        if (existingName != null)
        {
            WriteColored("\nA product with this NAME already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        string barcode = ReadString("Enter Barcode: ");

        var existingBarcode = productList.LinearSearchByBarcode(barcode);
        if (existingBarcode != null)
        {
            WriteColored("\nA product with this BARCODE already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        productList.Add(new Product { Id = id, Title = name, Barcode = barcode });

        WriteColored("\nProduct added successfully!", ConsoleColor.Green);
        Pause();
    }

    static void RemoveProduct()
    {
        DrawHeader("REMOVE PRODUCT");
        WriteColored("=== Remove Product ===\n", ConsoleColor.Blue);

        int id = ReadInt("Enter Product ID to remove: ");

        bool removed = productList.Remove(id);

        WriteColored(removed
            ? "\nProduct removed successfully!"
            : "\nProduct not found.", removed ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void UpdateProduct()
    {
        DrawHeader("UPDATE PRODUCT");
        WriteColored("=== Update Product ===\n", ConsoleColor.Blue);

        int id = ReadInt("Enter Product ID to update: ");

        string name = ReadString("Enter new Product Name: ");
        string barcode = ReadString("Enter new Barcode: ");

        bool updated = productList.Update(new Product { Id = id, Title = name, Barcode = barcode });

        WriteColored(updated
            ? "\nProduct updated successfully!"
            : "\nProduct not found.", updated ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void SearchProduct()
    {
        DrawHeader("SEARCH PRODUCT");
        WriteColored("=== Search Product ===\n", ConsoleColor.Blue);

        string name = ReadString("Enter Product Name: ");

        var product = productList.LinearSearchByName(name);

        if (product != null)
        {
            WriteColored("\nProduct Found:", ConsoleColor.Green);
            WriteColored($"ID: {product.Id}", ConsoleColor.DarkYellow);
            WriteColored($"Name: {product.Title}", ConsoleColor.DarkYellow);
            WriteColored($"Barcode: {product.Barcode}", ConsoleColor.DarkYellow);
        }
        else
        {
            WriteColored("\nProduct not found.", ConsoleColor.Red);
        }

        Pause();
    }

    static void ListProducts()
    {
        DrawHeader("ALL PRODUCTS");
        WriteColored("=== Product List ===\n", ConsoleColor.Blue);

        if (productList.Count == 0)
        {
            WriteColored("No products available.", ConsoleColor.Red);
        }
        else
        {
            for (int i = 0; i < productList.Count; i++)
            {
                var p = productList.GetAt(i);

                WriteColored($"ID: {p.Id}", ConsoleColor.DarkYellow);
                WriteColored($"Name: {p.Title}", ConsoleColor.DarkYellow);
                WriteColored($"Barcode: {p.Barcode}", ConsoleColor.DarkYellow);

                WriteColored("------------------------------------------------------------", ConsoleColor.DarkGray);
            }
        }

        Pause();
    }

    // ------------------ Category Management ------------------

    static void CategoryMenu()
    {
        while (true)
        {
            DrawHeader("CATEGORY MANAGEMENT");

            WriteColored("1. Add Category", ConsoleColor.DarkYellow);
            WriteColored("2. Remove Category", ConsoleColor.DarkYellow);
            WriteColored("3. Update Category", ConsoleColor.DarkYellow);
            WriteColored("4. List All Categories", ConsoleColor.DarkYellow);
            WriteColored("5. Back to Main Menu", ConsoleColor.DarkRed);

            Console.WriteLine();
            WriteColoredInline("Select an option: ", ConsoleColor.DarkGreen);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddCategory(); break;
                case "2": RemoveCategory(); break;
                case "3": UpdateCategory(); break;
                case "4": ListCategories(); break;
                case "5": return;

                default:
                    WriteColored("\nInvalid option. Press any key to continue...", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddCategory()
    {
        DrawHeader("ADD CATEGORY");

        int id = ReadInt("Enter Category ID: ");

        var existingId = categoryList.LinearSearchById(id);
        if (existingId != null)
        {
            WriteColored("\nA category with this ID already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        string name = ReadString("Enter Category Name: ");

        var existingName = categoryList.LinearSearchByName(name);
        if (existingName != null)
        {
            WriteColored("\nA category with this NAME already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        categoryList.Add(new Category { Id = id, Name = name });

        WriteColored("\nCategory added successfully!", ConsoleColor.Green);
        Pause();
    }

    static void RemoveCategory()
    {
        DrawHeader("REMOVE CATEGORY");

        int id = ReadInt("Enter Category ID to remove: ");

        bool removed = categoryList.Remove(id);

        WriteColored(removed
            ? "\nCategory removed successfully!"
            : "\nCategory not found.", removed ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void UpdateCategory()
    {
        DrawHeader("UPDATE CATEGORY");

        int id = ReadInt("Enter Category ID to update: ");

        string name = ReadString("Enter new Category Name: ");

        bool updated = categoryList.Update(new Category { Id = id, Name = name });

        WriteColored(updated
            ? "\nCategory updated successfully!"
            : "\nCategory not found.", updated ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void ListCategories()
    {
        DrawHeader("ALL CATEGORIES");

        if (categoryList.Count == 0)
        {
            WriteColored("No categories available.", ConsoleColor.Red);
        }
        else
        {
            for (int i = 0; i < categoryList.Count; i++)
            {
                var c = categoryList.GetAt(i);

                WriteColored($"ID: {c.Id}", ConsoleColor.DarkYellow);
                WriteColored($"Name: {c.Name}", ConsoleColor.DarkYellow);

                WriteColored("------------------------------------------------------------", ConsoleColor.DarkGray);
            }
        }

        Pause();
    }

    // ------------------ Supplier Management ------------------

    static void SupplierMenu()
    {
        while (true)
        {
            DrawHeader("SUPPLIER MANAGEMENT");

            WriteColored("1. Add Supplier", ConsoleColor.DarkYellow);
            WriteColored("2. Remove Supplier", ConsoleColor.DarkYellow);
            WriteColored("3. Update Supplier", ConsoleColor.DarkYellow);
            WriteColored("4. List All Suppliers", ConsoleColor.DarkYellow);
            WriteColored("5. Back to Main Menu", ConsoleColor.DarkRed);

            Console.WriteLine();
            WriteColoredInline("Select an option: ", ConsoleColor.DarkGreen);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddSupplier(); break;
                case "2": RemoveSupplier(); break;
                case "3": UpdateSupplier(); break;
                case "4": ListSuppliers(); break;
                case "5": return;

                default:
                    WriteColored("\nInvalid option. Press any key to continue...", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddSupplier()
    {
        DrawHeader("ADD SUPPLIER");

        int id = ReadInt("Enter Supplier ID: ");

        var existingId = supplierList.LinearSearchById(id);
        if (existingId != null)
        {
            WriteColored("\nA supplier with this ID already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        string name = ReadString("Enter Supplier Name: ");

        var existingName = supplierList.LinearSearchByName(name);
        if (existingName != null)
        {
            WriteColored("\nA supplier with this NAME already exists.", ConsoleColor.Red);
            Pause();
            return;
        }

        string contact = ReadString("Enter Supplier Contact Number: ");
        string email = ReadString("Enter Supplier Email: ");

        supplierList.Add(new Supplier
        {
            Id = id,
            Name = name,
            ContactNumber = contact,
            Email = email
        });

        WriteColored("\nSupplier added successfully!", ConsoleColor.Green);
        Pause();
    }

    static void RemoveSupplier()
    {
        DrawHeader("REMOVE SUPPLIER");

        int id = ReadInt("Enter Supplier ID to remove: ");

        bool removed = supplierList.Remove(id);

        WriteColored(removed
            ? "\nSupplier removed successfully!"
            : "\nSupplier not found.", removed ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void UpdateSupplier()
    {
        DrawHeader("UPDATE SUPPLIER");

        int id = ReadInt("Enter Supplier ID to update: ");

        string name = ReadString("Enter new Supplier Name: ");
        string contact = ReadString("Enter new Supplier Contact Number: ");
        string email = ReadString("Enter new Supplier Email: ");

        bool updated = supplierList.Update(new Supplier
        {
            Id = id,
            Name = name,
            ContactNumber = contact,
            Email = email
        });

        WriteColored(updated
            ? "\nSupplier updated successfully!"
            : "\nSupplier not found.", updated ? ConsoleColor.Green : ConsoleColor.Red);

        Pause();
    }

    static void ListSuppliers()
    {
        DrawHeader("ALL SUPPLIERS");

        if (supplierList.Count == 0)
        {
            WriteColored("No suppliers available.", ConsoleColor.Red);
        }
        else
        {
            for (int i = 0; i < supplierList.Count; i++)
            {
                var s = supplierList.GetAt(i);

                WriteColored($"ID: {s.Id}", ConsoleColor.DarkYellow);
                WriteColored($"Name: {s.Name}", ConsoleColor.DarkYellow);
                WriteColored($"Contact Number: {s.ContactNumber}", ConsoleColor.DarkYellow);
                WriteColored($"Email: {s.Email}", ConsoleColor.DarkYellow);

                WriteColored("------------------------------------------------------------", ConsoleColor.DarkGray);
            }
        }

        Pause();
    }

    // ------------------ Sales System ------------------

    static void SalesMenu()
    {
        while (true)
        {
            DrawHeader("SALES MANAGEMENT");

            WriteColored("1. Create New Sale", ConsoleColor.DarkYellow);
            WriteColored("2. Add Item to Sale", ConsoleColor.DarkYellow);
            WriteColored("3. List All Sales", ConsoleColor.DarkYellow);
            WriteColored("4. Show Sale Total", ConsoleColor.DarkYellow);
            WriteColored("5. Back to Main Menu", ConsoleColor.DarkRed);

            Console.WriteLine();
            WriteColoredInline("Select an option: ", ConsoleColor.DarkGreen);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddSale(); break;
                case "2": AddSaleItem(); break;
                case "3": ListSales(); break;
                case "4": ShowSaleTotal(); break;
                case "5": return;

                default:
                    WriteColored("\nInvalid option. Press any key to continue...", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddSale()
    {
        DrawHeader("CREATE NEW SALE");

        int id = ReadInt("Enter Sale ID: ");
        string customer = ReadString("Enter Customer Name: ");

        Sale sale = new Sale
        {
            Id = id,
            CustomerName = customer
        };

        salelist.Add(sale);

        WriteColored("\nSale created successfully!", ConsoleColor.Green);
        Pause();
    }

    static void AddSaleItem()
    {
        DrawHeader("ADD ITEM TO SALE");

        int saleId = ReadInt("Enter Sale ID: ");

        Sale sale = null;

        for (int i = 0; i < salelist.Count; i++)
        {
            if (salelist.GetAt(i).Id == saleId)
            {
                sale = salelist.GetAt(i);
                break;
            }
        }

        if (sale == null)
        {
            WriteColored("\nSale not found.", ConsoleColor.Red);
            Pause();
            return;
        }

        int productId = ReadInt("Enter Product ID: ");

        var product = productList.LinearSearchById(productId);

        if (product == null)
        {
            WriteColored("\nProduct not found.", ConsoleColor.Red);
            Pause();
            return;
        }

        int quantity = ReadInt("Enter Quantity: ");
        decimal price = decimal.Parse(ReadString("Enter Price: "));

        SaleItem item = new SaleItem
        {
            Id = sale.ItemCount + 1,
            ProductId = product.Id,
            Quantity = quantity,
            LineTotal = price * quantity
        };

        sale.AddItem(item);

        WriteColored("\nItem added to sale!", ConsoleColor.Green);
        Pause();
    }

    static void ListSales()
    {
        DrawHeader("ALL SALES");

        if (salelist.Count == 0)
        {
            WriteColored("No sales available.", ConsoleColor.Red);
        }
        else
        {
            for (int i = 0; i < salelist.Count; i++)
            {
                var sale = salelist.GetAt(i);

                WriteColored($"Sale ID: {sale.Id}", ConsoleColor.DarkYellow);
                WriteColored($"Customer: {sale.CustomerName}", ConsoleColor.DarkYellow);
                WriteColored($"Items: {sale.ItemCount}", ConsoleColor.DarkYellow);

                WriteColored("------------------------------------------------------------", ConsoleColor.DarkGray);
            }
        }

        Pause();
    }

    static void ShowSaleTotal()
    {
        DrawHeader("SALE TOTAL");

        int saleId = ReadInt("Enter Sale ID: ");

        Sale sale = null;

        for (int i = 0; i < salelist.Count; i++)
        {
            if (salelist.GetAt(i).Id == saleId)
            {
                sale = salelist.GetAt(i);
                break;
            }
        }

        if (sale == null)
        {
            WriteColored("\nSale not found.", ConsoleColor.Red);
            Pause();
            return;
        }

        decimal total = sale.GetTotal();

        WriteColored($"\nTotal Amount: £{total}", ConsoleColor.Green);
        Pause();
    }

    // ------------------ Exit ------------------

    static void Exit()
    {
        DrawHeader("EXIT");

        WriteColored("Thank you for using the Supermarket Management System.", ConsoleColor.Green);
        WriteColored("Goodbye!", ConsoleColor.Cyan);

        Console.WriteLine("\nPress any key to close...");
        Console.ReadKey();
    }
}