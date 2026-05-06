namespace WarehouseClasses;

public class Product
{
    private string _name;
    private decimal _price;
    private string _trademark;
    private int _quantity;

    public Product(string name, decimal price, string trademark, int quantity)
    {
        Name = name;
        Price = price;
        Trademark = trademark;
        Quantity = quantity;
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

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0m)
                throw new ArgumentOutOfRangeException(nameof(value), "Price must be a positive number!");
            _price = value;
        }
    }

    public string Trademark
    {
        get => _trademark;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Trademark can't be empty!", nameof(value));
            _trademark = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be a positive number");
            _quantity = value;
        }
    }

    public override string ToString()
    {
        return $"Product: {Name}, Trademark: {Trademark}, Price: {Price}, Quantity: {Quantity}";
    }
}