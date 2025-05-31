using Microsoft.EntityFrameworkCore;

public static class DbSetExtensions
{
    public static async Task<HashSet<TSource>> ToHashSetAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken cancellationToken = default)
    {
        var hashSet = new HashSet<TSource>();
        await foreach (var element in source.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            hashSet.Add(element);
        }
        return hashSet;
    }

}