namespace WarehouseClasses;

public class Supplier : Person
{
    private string _company;

    public Supplier(string name, string surname, string company) : base(name, surname)
    {
        Company = company;
    }

    public string Company
    {
        get => _company;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value), "Company can't be empty!");
            _company = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Company: {Company}";
    }
}