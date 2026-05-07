namespace WarehouseClasses;

public class Warehouse
{
    public Warehouse()
    {
        Categories = new CategoryManager();
        Products = new ProductManager(Categories);
        Suppliers = new SupplierManager();
    }

    public CategoryManager Categories
    {
        get;
        init;
    }

    public ProductManager Products
    {
        get;
        init;
    }

    public SupplierManager Suppliers
    {
        get;
        init;
    }
    
}