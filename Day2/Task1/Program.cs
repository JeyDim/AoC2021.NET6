using static CommonFunctions.Helpers;

ReadAllData()
    .Select(s => (command: s[0], value: int.Parse(s.Split(" ")[1])))
    .Aggregate(
    (horizontalPos: 0, depth: 0),
    (pos, curr) =>
        curr.command switch
        {
            'u' => (pos.horizontalPos, pos.depth - curr.value),
            'd' => (pos.horizontalPos, pos.depth + curr.value),
            _ => (pos.horizontalPos + curr.value, pos.depth)
        }
    )
    .Then(acc => acc.horizontalPos * acc.depth)
    .Then(Console.WriteLine);