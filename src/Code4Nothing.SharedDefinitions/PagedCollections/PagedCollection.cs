namespace Code4Nothing.SharedDefinitions.PagedCollections;

public class PagedCollection<T> : IPagedCollection<T> where T: class
{
    public int PageFrom { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage => PageIndex > PageFrom;
    public bool HasNextPage => PageIndex - PageFrom + 1 < TotalPages;
    public IList<T> Items { get; set; }

    public PagedCollection(IEnumerable<T> source, int pageIndex, int pageSize, int pageFrom)
    {
        if (pageFrom > pageIndex)
        {
            throw new ArgumentException($"pageFrom: {pageFrom} > pageIndex: {pageIndex}, pageFrom must less or equal to pageIndex");
        }

        PageIndex = pageIndex;
        PageSize = pageSize;
        PageFrom = pageFrom;
        TotalCount = source.Count();
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        Items = source.Skip((PageIndex - PageFrom) * PageSize).Take(PageSize).ToList();
    }

    internal PagedCollection() => Items = Array.Empty<T>();
}

internal class PagedCollection<TSource, TResult> : IPagedCollection<TResult> 
    where TResult: class
    where TSource: class
{
    public int PageFrom { get; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public bool HasPreviousPage => PageIndex > PageFrom;
    public bool HasNextPage => PageIndex - PageFrom + 1 < TotalPages;
    public IList<TResult> Items { get; }
    
    public PagedCollection(
        IEnumerable<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
        int pageIndex,
        int pageSize,
        int pageFrom)
    {
        if (pageFrom > pageIndex)
        {
            throw new ArgumentException($"pageFrom: {pageFrom} > pageIndex: {pageIndex}, pageFrom must less or equal to pageIndex");
        }

        PageIndex = pageIndex;
        PageSize = pageSize;
        PageFrom = pageFrom;
        TotalCount = source.Count();
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        var items = source.Skip((PageIndex - PageFrom) * PageSize).Take(PageSize).ToList();

        Items = new List<TResult>(converter(items));
    }
    
    public PagedCollection(IPagedCollection<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        PageIndex = source.PageIndex;
        PageSize = source.PageSize;
        PageFrom = source.PageFrom;
        TotalCount = source.TotalCount;
        TotalPages = source.TotalPages;

        Items = new List<TResult>(converter(source.Items));
    }
}
