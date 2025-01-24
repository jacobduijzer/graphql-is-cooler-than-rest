namespace SnackFlix.Snacks;

public class HashSetComparer<T> : IEqualityComparer<HashSet<T>>
{
    public static readonly HashSetComparer<T> Default = new HashSetComparer<T>();

    public bool Equals(HashSet<T> x, HashSet<T> y)
    {
        return x.SetEquals(y);
    }

    public int GetHashCode(HashSet<T> obj)
    {
        return obj.Aggregate(19, (current, item) => current * 31 + item.GetHashCode());
    }
}