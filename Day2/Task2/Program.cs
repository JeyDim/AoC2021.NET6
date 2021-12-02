(int, int, int) AggregateFunc((int horizontalPos, int depth, int aim) tuple, string currentCommand)
{
    var split = currentCommand.Split(' ');
    var command = split[0];
    var value = int.Parse(split[1]);
    switch (command)
    {
        case "forward":
            tuple.horizontalPos += value;
            tuple.depth += value * tuple.aim;
            break;
        case "down":
            tuple.aim += value;
            break;
        case "up":
            tuple.aim -= value;
            break;
    }
    return tuple;
}

var (horizontalPos, depth, aim) = CommonFunctions.ReadFunctions.ReadAllData()
    .TakeWhile(s => !s.Equals(string.Empty))
    .Aggregate(
    (horisontalPos: 0, depth: 0, aim: 0),
    AggregateFunc);

Console.WriteLine(horizontalPos * depth);
