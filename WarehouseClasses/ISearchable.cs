namespace WarehouseClasses;

public interface ISearchable<T>
{
    List<T> SearchByKeyword(string keyword);
}