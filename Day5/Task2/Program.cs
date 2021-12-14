using static CommonFunctions.Helpers;

var data = ReadAllData()
    .Select(s => s.Replace(" -> ", ",").Split(','))
    .Select(s => (x1: int.Parse(s[0]), y1: int.Parse(s[1]), x2: int.Parse(s[2]), y2: int.Parse(s[3])))
    .ToList();

var map = new int [1000, 1000];


foreach (var vent in data)
{
    var dx = Math.Sign(vent.x2 - vent.x1);
    var dy = Math.Sign(vent.y2 - vent.y1);

    var x = vent.x1;
    var y = vent.y1;
    while (x != vent.x2 + dx || y != vent.y2 + dy)
    {
        map[x, y]++;
        x += dx;
        y += dy;
    }
}

var sum = map.Cast<int>().Count(value => value > 1);

Console.WriteLine(sum);
