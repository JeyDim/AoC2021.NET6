using static CommonFunctions.Helpers;

var winNumbers = Console.ReadLine()!.Split(',').ToList();

Dictionary<int, List<string[]>> boards = new();
var endOfContent = false;
var id = 0;
do
{
    var data = ReadAllData().ToList();
    if (data.Count > 0)
    {
        boards.Add(id++, data.Select(x => x.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray()).ToList());
    }
    else
    {
        if (endOfContent)
            break;

        endOfContent = true;
    }
} while (true);

var winners = new List<int>();
foreach (var number in winNumbers)
{
    foreach (var board in boards)
    {
        foreach (var row in board.Value)
        {
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i].Equals(number))
                    row[i] = "z";
            }
        }
        if (CheckBoard(board.Value))
        {
            if (winners.Contains(board.Key))
                continue;

            if (winners.Count < boards.Count - 1)
            {
                winners.Add(board.Key);
            }
            else
            {
                var sum = board.Value.Select(row => row.Where(x => !x.Equals("z"))
                        .Select(x => Convert.ToInt32(x))
                        .ToList())
                    .Select(numbers => numbers.Sum())
                    .Sum();
                Console.WriteLine(sum * Convert.ToInt32(number));
                return;
            }
        }
    }
}

bool CheckBoard(IReadOnlyCollection<string[]> board)
{
    if (board.Any(row => row.All(c => c == "z")))
    {
        return true;
    }
    for (var i = 0; i < board.Count; i++)
    {
        if (board.Select(row => row[i]).All(c => c == "z"))
            return true;
    }
    return false;
}
