namespace WarehouseClasses;

public class ProductManager : ISearchable<Product>
{
    private readonly CategoryManager _categoryManager;

    public ProductManager(CategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

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
        return _categoryManager.Categories.SelectMany(x => x.Products).ToList();
    }

    public IReadOnlyList<Product> SortAllProductsByName() => GetAllProducts().OrderBy(x => x.Name).ToList();

    public IReadOnlyList<Product> SortAllProductsByTrademark() => GetAllProducts().OrderBy(x => x.Trademark).ToList();

    public IReadOnlyList<Product> SortAllProductsByPrice() => GetAllProducts().OrderBy(x => x.Price).ToList();

    public List<Product> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("keyword can't be empty", nameof(keyword));
        
        return GetAllProducts().Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ||  x.Trademark.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}