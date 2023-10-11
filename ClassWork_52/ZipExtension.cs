namespace ClassWork_52;

public static class ZipExtension
{
    public static IEnumerable<(TPost, TPost)> ZipExtensions<TPost, TKey>(
                    this ICollection<TPost> postA,
                    ICollection<TPost> postB, 
                    Func<TPost, TKey> keySelector
                    ) where TPost : notnull
    {
        if (postA is null)
            throw new ArgumentNullException(nameof(postA));
        
        if (postA is null)
            throw new ArgumentNullException(nameof(postA));

        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));

        return ZipPer(postA, postB, keySelector);
    }

    private static IEnumerable<(TPost, TPost)> ZipPer<TPost, TKey>(
                    this ICollection<TPost> postA,
                    ICollection<TPost> postB,
                    Func<TPost, TKey> keySelector
    ) where TPost : notnull
    {
        foreach (var itemA in postA)
        {
            var key = keySelector(itemA);
            var itemB = postB.FirstOrDefault(post => keySelector(post).Equals(key));
            
            if (itemB is not null)
                yield return (itemA, itemB);
        }
    }
}