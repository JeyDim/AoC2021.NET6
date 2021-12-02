namespace CommonFunctions;

public static class ReadFunctions
{
    public static IEnumerable<string> ReadAllData()
    {
        while (true)
            yield return Console.ReadLine() ?? string.Empty;
        // ReSharper disable once IteratorNeverReturns
    }
}
