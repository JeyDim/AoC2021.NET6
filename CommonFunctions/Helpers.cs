namespace CommonFunctions;

public static class Helpers
{
    /// <summary>
    /// Read data
    /// </summary>
    private static IEnumerable<string> Read()
    {
        while (true)
            yield return Console.ReadLine() ?? string.Empty;
        // ReSharper disable once IteratorNeverReturns
    }
    
    /// <summary>
    /// Read data until empty line
    /// </summary>
    public static IEnumerable<string> ReadAllData() => Read()
        .TakeWhile(s => !s.Equals(string.Empty));

    //pipe-forward extension methods
    public static U Then<T, U>(this T input, Func<T, U> fun) => fun(input);
    public static void Then<T>(this T input, Action<T> fun) => fun(input);
}
