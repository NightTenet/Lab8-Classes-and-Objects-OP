namespace WarehouseClasses;

public class Warehouse : ISearchable<Product>, ISearchable<Supplier>
{
    private List<Category> _categoryList;
    private List<Supplier> _supplierList;

    public Warehouse()
    {
        _categoryList = new List<Category>();
        _supplierList = new List<Supplier>();
    }

    public void AddCategory(Category category)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category), "Category can't be empty!");
        _categoryList.Add(category);
    }

    public bool RemoveCategory(Category category)
    {
        return _categoryList.Remove(category);
    }

    public void ChangeCategoryData(Category category, string newName)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category), "Category can't be empty!");
        category.Name = newName;
    }

    public Category? GetCategoryByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name can't be empty!", nameof(name));
        
        return _categoryList.FirstOrDefault(x => x.Name == name);
    }

    public IReadOnlyList<Category> Categories => _categoryList;



    public void AddProductToCategory(Category category, Product product)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category), "Category is empty!");
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Your product is empty!");
        
        category.AddProduct(product);
    }

    public void RemoveProductInCategory(Category category, Product product)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category), "Category name is empty!");
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Your product is empty!");
        
        category.RemoveProduct(product);
    }

    public void ChangeProductData(Product product, string newName, int newQuantity,
    decimal newPrice, string newTrademark)
    {
        if (product is null)
            throw new ArgumentException("Product name is empty!", nameof(product));
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Product name is empty!", nameof(newName));
        if (string.IsNullOrWhiteSpace(newTrademark))
            throw new ArgumentException("Product name is empty!", nameof(newTrademark));
        

        product.Name = newName;
        product.Quantity = newQuantity;
        product.Price = newPrice;
        product.Trademark = newTrademark;
    }

    public void ChangeProductQuantity(Product product, int newQuantity)
    {
        if (product is null)
            throw new ArgumentException("Product name is empty!", nameof(product));

        product.Quantity = newQuantity;
    }

    public Product GetProductByName(string name, Category? category = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is empty!", nameof(name));

        if (category != null)
            return category.Products.FirstOrDefault(x => x.Name == name);

        var allProducts = GetAllProducts();
        return allProducts.FirstOrDefault(x => x.Name == name);
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _categoryList.SelectMany(x => x.Products).ToList();
    }

    public IReadOnlyList<Product> SortAllProductsByName() => GetAllProducts().OrderBy(x => x.Name).ToList();

    public IReadOnlyList<Product> SortAllProductsByTrademark() => GetAllProducts().OrderBy(x => x.Trademark).ToList();

    public IReadOnlyList<Product> SortAllProductsByPrice() => GetAllProducts().OrderBy(x => x.Price).ToList();



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

    public List<Product> SearchByKeywordInProducts(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("keyword can't be empty", nameof(keyword));
        
        return GetAllProducts().Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ||  x.Trademark.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Supplier> SearchByKeywordInSuppliers(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("keyword can't be empty", nameof(keyword));
        
        return Suppliers.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ||  x.Surname.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            || x.Company.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    List<Product> ISearchable<Product>.SearchByKeyword(string keyword) => SearchByKeywordInProducts(keyword);
    
    List<Supplier> ISearchable<Supplier>.SearchByKeyword(string keyword) => SearchByKeywordInSuppliers(keyword);
}