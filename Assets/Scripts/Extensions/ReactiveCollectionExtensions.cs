using UniRx;

public static class ReactiveCollectionExtensions
{
    public static string ToString<T>(this ReactiveCollection<T> list)
    {
        var result = string.Join(", ", list);

        return result;
    }
}
