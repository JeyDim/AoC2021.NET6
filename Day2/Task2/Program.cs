using static CommonFunctions.Helpers;

ReadAllData()
    .Select(s => (command: s[0], value: int.Parse(s.Split(" ")[1])))
    .Aggregate(
    (horizontalPos: 0, depth: 0, aim: 0),
    (prev, curr) =>
        curr.command switch
        {
            'd' => (prev.horizontalPos, prev.depth, prev.aim + curr.value),
            'u' => (prev.horizontalPos, prev.depth, prev.aim - curr.value),
            _ => (prev.horizontalPos + curr.value, prev.depth + prev.aim * curr.value, prev.aim)
        }
    )
    .Then(pos => pos.horizontalPos * pos.depth)
    .Then(Console.WriteLine);
