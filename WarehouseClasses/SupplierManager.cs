namespace WarehouseClasses;

public class SupplierManager : ISearchable<Supplier>
{
    private List<Supplier> _supplierList;

    public SupplierManager()
    {
        _supplierList = new List<Supplier>();
    }

    public void AddSupplier(Supplier supp)
    {
        if (supp is null)
            throw new ArgumentNullException(nameof(supp), "Supp can't be empty!");
        _supplierList.Add(supp);
    }

    public bool RemoveSupplier(Supplier supp)
    {
        return _supplierList.Remove(supp);
    }

    public void ChangeSupplierData(Supplier supp, string newName, string newSurname, string newCompany)
    {
        if (supp is null)
            throw new ArgumentNullException(nameof(supp), "Supplier can't be empty!");

        supp.Name = newName;
        supp.Surname = newSurname;
        supp.Company = newCompany;
    }

    public Supplier GetSupplierByNS(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is empty!", nameof(name));
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("Product name is empty!", nameof(surname));
        
        return _supplierList.FirstOrDefault(x => x.Name == name && x.Surname == surname);
    }

    public IReadOnlyList<Supplier> Suppliers => _supplierList;

    public IReadOnlyList<Supplier> SortAllSuppliersByName() => Suppliers.OrderBy(x => x.Name).ToList();

    public IReadOnlyList<Supplier> SortAllSuppliersBySurname() => Suppliers.OrderBy(x => x.Surname).ToList();

    public List<Supplier> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("keyword can't be empty", nameof(keyword));
        
        return Suppliers.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ||  x.Surname.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            || x.Company.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}