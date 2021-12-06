using static CommonFunctions.Helpers;

var winNumbers = Console.ReadLine()!.Split(',').ToList();

List<List<string[]>> boards = new();
var endOfContent = false;
do
{
    var data = ReadAllData().ToList();
    if (data.Count > 0)
    {
        boards.Add(data.Select(x => x.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray()).ToList());
    }
    else
    {
        if (endOfContent)
            break;

        endOfContent = true;
    }
} while (true);

foreach (var number in winNumbers)
{
    foreach (var board in boards)
    {
        foreach (var row in board)
        {
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i].Equals(number))
                    row[i] = "z";
            }
        }
        if (CheckBoard(board))
        {
            var sum = board.Select(row => row.Where(x => !x.Equals("z"))
                    .Select(x => Convert.ToInt32(x))
                    .ToList())
                .Select(numbers => numbers.Sum())
                .Sum();
            Console.WriteLine(sum * Convert.ToInt32(number));
            return;
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
