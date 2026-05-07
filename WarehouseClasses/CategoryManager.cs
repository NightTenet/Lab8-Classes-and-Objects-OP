namespace WarehouseClasses;

public class CategoryManager
{
    private List<Category> _categoryList;

    public CategoryManager()
    {
        _categoryList = new List<Category>();
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
}