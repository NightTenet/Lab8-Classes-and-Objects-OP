namespace WarehouseClasses;

public class Category
{
    private string _name;
    private List<Product> _productList;

    public Category(string name)
    {
        Name = name;
        _productList = new List<Product>();
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name can't be empty!", nameof(value));
            _name = value;
        }
    }

    public IReadOnlyList<Product> Products => _productList;

    public void AddProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Product can't be empty!");
        _productList.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _productList.Remove(product);
    }

    public override string ToString()
    {
        return $"Category: {Name}, Products: {_productList.Count()}\n";
    }
}