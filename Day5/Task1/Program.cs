using static CommonFunctions.Helpers;

var data = ReadAllData()
    .Select(s => s.Replace(" -> ", ",").Split(','))
    .Select(s => s.Select(d => Convert.ToInt32(d)).ToList())
    .ToList();

var map = new int [1000, 1000];


foreach (var vent in data)
{
    int min, max;
    if (vent[1] == vent[3] && vent[0] != vent[2])
    {
        min = Math.Min(vent[0], vent[2]);
        max = Math.Max(vent[0], vent[2]);
        for (var i = min; i <= max; i++)
        {
            map[vent[1], i]++;
        }
    }

    if (vent[0] == vent[2] && vent[1] != vent[3])
    {
        min = Math.Min(vent[1], vent[3]);
        max = Math.Max(vent[1], vent[3]);
        for (var i = min; i <= max; i++)
        {
            map[i, vent[0]]++;
        }
    }
}

var sum = map.Cast<int>().Count(value => value > 1);

Console.WriteLine(sum);
