namespace Code4Nothing.SharedDefinitions.Extensions;

public static class EnumerablePagedCollectionExtensions
{
    public static IPagedCollection<T> ToPagedCollection<T>(
        this IEnumerable<T> source,
        int pageIndex,
        int pageSize,
        int pageFrom = 0) where T: class
        => new PagedCollection<T>(source, pageIndex, pageSize, pageFrom);
    
    public static IPagedCollection<TResult> ToPagedCollection<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
        int pageIndex,
        int pageSize,
        int indexFrom = 0) where TSource: class where TResult: class
        => new PagedCollection<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom);
}
