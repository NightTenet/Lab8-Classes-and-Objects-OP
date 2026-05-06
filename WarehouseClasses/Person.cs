namespace WarehouseClasses;

public abstract class Person
{
    private string _name;
    private string _surname;

    protected Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value), "Name can't be empty!");
            _name = value;
        }
    }

    public string Surname   
    {
        get => _surname;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value), "Surname can't be empty!");
            _surname = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}";
    }
}