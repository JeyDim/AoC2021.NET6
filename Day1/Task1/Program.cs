

(int, int) AggregateFunc((int previosValue, int count) tuple, int currentValue)
{
    tuple.count += currentValue > tuple.previosValue
        ? 1
        : 0;
    tuple.previosValue = currentValue;
    return tuple;
}

Console.WriteLine(CommonFunctions.Helpers.ReadAllData()
    .Select(int.Parse)
    .Aggregate(
    (prev: int.MaxValue, count: 0),
    AggregateFunc).count
);
