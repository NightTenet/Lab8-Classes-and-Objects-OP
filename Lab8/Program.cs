using WarehouseClasses;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse wh = new Warehouse();
            string? choice = "-1";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("========================= MENU =========================");
                Console.WriteLine($"{"1. Add a category", -45}11. Show all products");
                Console.WriteLine($"{"2. Delete a category", -45}12. Add a supplier");
                Console.WriteLine($"{"3. Change specific category data", -45}13. Delete a supplier");
                Console.WriteLine($"{"4. Show specific category", -45}14. Change specific supplier data");
                Console.WriteLine($"{"5. Show all categories", -45}15. Show specific supplier data");
                Console.WriteLine($"{"6. Add a product to category", -45}16. Show all suppliers");
                Console.WriteLine($"{"7. Delete a product from category", -45}17. Search by keyword in products");
                Console.WriteLine($"{"8. Change specific product data", -45}18. Search by keyword in suppliers");
                Console.WriteLine($"{"9. Change quantity of product in warehouse", -45}0. EXIT");
                Console.WriteLine($"10. Show specific product data\n\nEnter a choice: ");

                choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            {
                                Console.WriteLine("\nEnter a category name: ");

                                string name = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(name))
                                    throw new ArgumentException("Name can't be empty!", nameof(name));

                                Category cat = new Category(name);
                                wh.Categories.AddCategory(cat);

                                Console.WriteLine("\nCategory successfully added!");
                                break;
                            }

                        case "2":
                            {
                                Console.WriteLine("\nEnter category name to delete: ");
                                string name = Console.ReadLine();

                                Category? cat = wh.Categories.GetCategoryByName(name);
                                if (wh.Categories.RemoveCategory(cat))
                                    Console.WriteLine("\nCategory successfully deleted!");
                                else
                                    Console.WriteLine("\nThere's no such category!");

                                break;
                            }

                        case "3":
                            {
                                Console.WriteLine("\nEnter category name to change it data: ");
                                string oldName = Console.ReadLine();
                                Console.WriteLine("\nEnter new name for that category: ");
                                string newName = Console.ReadLine();

                                Category? cat = wh.Categories.GetCategoryByName(oldName);
                                if (cat != null)
                                {
                                    wh.Categories.ChangeCategoryData(cat, newName);
                                    Console.WriteLine("\nCategory data changed successfully!");
                                }
                                else
                                    Console.WriteLine("\nThere's no such category!");
                                
                                break;
                            }

                        case "4":
                            {
                                Console.WriteLine("\nEnter category name to find it: ");
                                string name = Console.ReadLine();

                                Category? cat = wh.Categories.GetCategoryByName(name);
                                if (cat != null)
                                    Console.WriteLine("\n" + cat.ToString());
                                else
                                    Console.WriteLine("\nThere's no such category!");

                                break;
                            }

                        case "5":
                            {
                                var catList = wh.Categories.Categories;

                                if (catList.Count == 0)
                                    Console.WriteLine("List is empty!");
                                else
                                {
                                    Console.WriteLine("----- List of Categories -----");
                                    foreach (var cat in catList)
                                    {
                                        Console.WriteLine(cat.ToString());
                                    }
                                }
                                
                                break;
                            }

                        case "6":
                            {
                                Console.WriteLine("\nEnter category name to which add a product: ");
                                string catName = Console.ReadLine();

                                Category cat = wh.Categories.GetCategoryByName(catName);
                                if (cat == null)
                                    Console.WriteLine("\nThere's no such category!");
                                else
                                {
                                    Console.WriteLine("\nEnter product name which you want to add: ");
                                    string prodName = Console.ReadLine();
                                    Console.WriteLine("\nEnter product price: ");
                                    decimal price = decimal.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter quantity of product: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter product trademark: ");
                                    string trademark = Console.ReadLine();

                                    Product prod = new Product(prodName, price,trademark, quantity);
                                    wh.Products.AddProductToCategory(cat, prod);
                                    Console.WriteLine("\nProduct added successfully!");
                                }

                                break;
                            }

                        case "7":
                            {
                                Console.WriteLine("\nEnter category name in which delete a product: ");
                                string catName = Console.ReadLine();

                                Category cat = wh.Categories.GetCategoryByName(catName);
                                if (cat == null)
                                    Console.WriteLine("\nThere's no such category!");
                                else
                                {
                                    Console.WriteLine("\n\nEnter product name which you want to delete: ");
                                    string prodName = Console.ReadLine();

                                    Product prod = wh.Products.GetProductByName(prodName, cat);
                                    if (prod == null)
                                        Console.WriteLine("There's no such product in that category!");
                                    else
                                    {
                                        wh.Products.RemoveProductInCategory(cat, prod);
                                        Console.WriteLine("Product deleted successfully!");
                                    }
                                }

                                break;
                            }

                        case "8":
                            {
                                Console.WriteLine("\nEnter product name which data you want to change: ");
                                string oldName = Console.ReadLine();

                                Product prod = wh.Products.GetProductByName(oldName);
                                if (prod == null)
                                    Console.WriteLine("There's no such product!");
                                else
                                {
                                    Console.WriteLine("\nEnter new product name: ");
                                    string newName = Console.ReadLine();
                                    Console.WriteLine("\nEnter new product price: ");
                                    decimal price = decimal.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter new quantity of product: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter new product trademark: ");
                                    string trademark = Console.ReadLine();

                                    wh.Products.ChangeProductData(prod, newName, quantity, price, trademark);
                                    Console.WriteLine("\nProduct data changed successfully!");
                                }
                                
                                break;
                            }

                        case "9":
                            {
                                Console.WriteLine("\nEnter product name which quantity you want to change: ");
                                string oldName = Console.ReadLine();

                                Product prod = wh.Products.GetProductByName(oldName);
                                if (prod == null)
                                    Console.WriteLine("There's no such product!");
                                else
                                {
                                    Console.WriteLine("\n\nEnter new product quantity: ");
                                    int quantity = int.Parse(Console.ReadLine());

                                    wh.Products.ChangeProductQuantity(prod, quantity);
                                    Console.WriteLine("\nProduct quantity changed successfully!");
                                }

                                break;
                            }
                        
                        case "10":
                            {
                                Console.WriteLine("\nEnter product name to find it: ");
                                string name = Console.ReadLine();

                                Product? prod = wh.Products.GetProductByName(name);
                                if (prod != null)
                                    Console.WriteLine("\n" + prod.ToString());
                                else
                                    Console.WriteLine("\nThere's no such product!");
                                break;
                            }

                        case "11":
                            {
                                var prodList = wh.Products.GetAllProducts();
                                if (prodList.Count == 0)
                                    Console.WriteLine("List is empty!");
                                else
                                {
                                    Console.WriteLine("How do you want to sort this list ");
                                    Console.Write("(1 - by name, 2 - by trademark, 3- by price)?\nChoice:");
                                    string sortChoice = Console.ReadLine();

                                    var sortedList = prodList;
                                    switch (sortChoice)
                                    {
                                        case "1":
                                                sortedList = wh.Products.SortAllProductsByName();
                                                break;
                                        case "2":
                                                sortedList = wh.Products.SortAllProductsByTrademark();
                                                break;
                                        case "3":
                                                sortedList = wh.Products.SortAllProductsByPrice();
                                                break;
                                    }
                                    Console.WriteLine("----- List of Products -----");
                                    foreach (var prod in sortedList)
                                    {
                                        Console.WriteLine(prod.ToString());
                                    }
                                }

                                break;
                            }

                        case "12":
                            {
                                Console.WriteLine("\nEnter supplier name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("\nEnter supplier surname: ");
                                string surname = Console.ReadLine();
                                Console.WriteLine("\nEnter supplier company: ");
                                string company = Console.ReadLine();

                                Supplier supp = new Supplier(name, surname, company);
                                wh.Suppliers.AddSupplier(supp);
                                Console.WriteLine("\nSupplier successfully added!");

                                break;
                            }

                        case "13":
                            {
                                Console.WriteLine("\nEnter supplier name you want delete: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("\nEnter supplier surname you want delete: ");
                                string surname = Console.ReadLine();

                                Supplier? supp = wh.Suppliers.GetSupplierByNS(name, surname);
                                if (wh.Suppliers.RemoveSupplier(supp))
                                    Console.WriteLine("\nSupplier successfully deleted!");
                                else
                                    Console.WriteLine("\nThere's no such supplier!");

                                break;
                            }
                        
                        case "14":
                            {
                                Console.WriteLine("\nEnter supplier name to change it data: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("\nEnter supplier surname to change it data: ");
                                string surname = Console.ReadLine();

                                Supplier? supp = wh.Suppliers.GetSupplierByNS(name, surname);
                                if (supp != null)
                                {
                                    Console.WriteLine("\nEnter new name for that supplier: ");
                                    string newName = Console.ReadLine();
                                    Console.WriteLine("\nEnter new surname for that supplier: ");
                                    string newSurname = Console.ReadLine();
                                    Console.WriteLine("\nEnter new company for that supplier: ");
                                    string newCompany = Console.ReadLine();

                                    wh.Suppliers.ChangeSupplierData(supp, newName, newSurname, newCompany);
                                    Console.WriteLine("\nSupplier data changed successfully!");
                                }
                                else
                                    Console.WriteLine("\nThere's no such supplier!");
                                    
                                break;
                            }

                        case "15":
                            {
                                Console.WriteLine("\nEnter supplier name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("\nEnter supplier surname: ");
                                string surname = Console.ReadLine();

                                Supplier? supp = wh.Suppliers.GetSupplierByNS(name, surname);
                                if (supp != null)
                                    Console.WriteLine("\n" + supp.ToString());
                                else
                                    Console.WriteLine("\nThere's no such supplier!");
                                
                                break;
                            }
                        
                        case "16":
                            {
                                var suppList = wh.Suppliers.Suppliers;

                                if (suppList.Count == 0)
                                    Console.WriteLine("List is empty!");
                                else
                                {
                                    Console.WriteLine("How do you want to sort this list ");
                                    Console.Write("(1 - by name, 2 - by surname)?\nChoice:");
                                    string sortChoice = Console.ReadLine();

                                    var sortedList = suppList;
                                    switch (sortChoice)
                                    {
                                        case "1":
                                                sortedList = wh.Suppliers.SortAllSuppliersByName();
                                                break;
                                        case "2":
                                                sortedList = wh.Suppliers.SortAllSuppliersBySurname();
                                                break;
                                        default:
                                            break;
                                    }

                                    Console.WriteLine("----- List of Suppliers -----");
                                    foreach (var supp in sortedList)
                                    {
                                        Console.WriteLine(supp.ToString());
                                    }
                                }

                                break;
                            }

                        case "17":
                            {
                                Console.WriteLine("\nEnter keyword to search in products: ");
                                string keyword = Console.ReadLine();

                                var result = wh.Products.SearchByKeyword(keyword);

                                if (result.Count == 0)
                                {
                                    Console.WriteLine("\nThere's no products!");
                                }
                                else
                                {
                                    Console.WriteLine("\n----- List of Found Products -----");
                                    foreach (var prod in result)
                                    {
                                        Console.WriteLine(prod.ToString());
                                    }
                                }
                                break;
                            }

                        case "18":
                            {
                                Console.WriteLine("\nEnter keyword to search in suppliers: ");
                                string keyword = Console.ReadLine();

                                var result = wh.Suppliers.SearchByKeyword(keyword);

                                if (result.Count == 0)
                                {
                                    Console.WriteLine("\nThere's no suppliers!");
                                }
                                else
                                {
                                    Console.WriteLine("\n----- List of Found Suppliers -----");
                                    foreach (var supp in result)
                                    {
                                        Console.WriteLine(supp.ToString());
                                    }
                                }
                                break;
                            }
                        
                        case "0":
                            {
                                choice = "0";
                                break;
                            }

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                Console.ReadKey();
            }
        }
    }
}