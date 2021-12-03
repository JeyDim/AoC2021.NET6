using static CommonFunctions.Helpers;

var reads = ReadAllData().ToList();

var validGammas = Enumerable.Range(0, reads.Count).ToList();
var validEpsilons = Enumerable.Range(0, reads.Count).ToList();

for (var i = 0; i < reads[0].Length; i++)
{
    validGammas = validGammas.Count(j => reads[j][i] == '0') > validGammas.Count / 2
        ? validGammas.Where(j => reads[j][i] == '0').ToList()
        : validGammas.Where(j => reads[j][i] == '1').ToList();
    
    if (validGammas.Count == 1) break;
}


for (var i = 0; i < reads[0].Length; i++)
{
    validEpsilons = validEpsilons.Count(j => reads[j][i] == '0') <= validEpsilons.Count / 2
        ? validEpsilons.Where(j => reads[j][i] == '0').ToList()
        : validEpsilons.Where(j => reads[j][i] == '1').ToList();
    
    if (validEpsilons.Count == 1) break;
}

var gammaInt = Convert.ToInt32(reads[validGammas.First()], 2);
var epsilonInt = Convert.ToInt32(reads[validEpsilons.First()], 2);

Console.WriteLine(gammaInt * epsilonInt);
