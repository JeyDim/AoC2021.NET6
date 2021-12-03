(int, int, int, int) AggregateFunc((int firstValue, int secondValue, int thirdValue, int count) tuple, int currentValue)
{
    tuple.count += tuple.secondValue + tuple.thirdValue + currentValue > tuple.firstValue + tuple.secondValue + tuple.thirdValue
        ? 1
        : 0;
    (tuple.firstValue, tuple.secondValue, tuple.thirdValue) = (tuple.secondValue, tuple.thirdValue, currentValue);
    return tuple;
}

Console.WriteLine(CommonFunctions.Helpers.ReadAllData()
    .Select(int.Parse)
    .Aggregate(
    (firstValue: int.MaxValue, secondValue: int.MaxValue, thirdValue: int.MaxValue, count: 0),
    AggregateFunc)
    .count - 1
);
