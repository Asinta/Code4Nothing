namespace Code4Nothing.SharedDefinitions.PagedCollections;

public interface IPagedCollection<T> where T: class
{
    int PageFrom { get; }
    int PageIndex { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPages { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
    IList<T> Items { get; }
}
