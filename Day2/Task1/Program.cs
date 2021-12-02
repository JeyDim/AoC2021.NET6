(int, int) AggregateFunc((int horizontalPos, int depth) tuple, string currentCommand)
{
    var split = currentCommand.Split(' ');
    var command = split[0];
    var value = int.Parse(split[1]);
    switch (command)
    {
        case "forward":
            tuple.horizontalPos += value;
            break;
        case "down":
            tuple.depth += value;
            break;
        case "up":
            tuple.depth -= value;
            break;
    }
    return tuple;
}

var (horizontalPos, depth) = CommonFunctions.ReadFunctions.ReadAllData()
    .TakeWhile(s => !s.Equals(string.Empty))
    .Aggregate(
    (horisontalPos: 0, depth: 0),
    AggregateFunc);

Console.WriteLine(horizontalPos * depth);
