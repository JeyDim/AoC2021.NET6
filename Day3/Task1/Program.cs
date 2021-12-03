using static System.Linq.Enumerable;
using static CommonFunctions.Helpers;

var data = ReadAllData().ToList();

Range(0, data[0].Length)
    .Aggregate((gamma: "", epsilon: ""),
    (result, i) =>
        Range(0, data.Count)
            .Count(j => data[j][i] == '0') > data.Count / 2
            ? (result.gamma + '0', result.epsilon + '1')
            : (result.gamma + '1', result.epsilon + '0'))
    .Then(result => Convert.ToInt32(result.gamma, 2) * Convert.ToInt32(result.epsilon, 2))
    .Then(Console.WriteLine);
