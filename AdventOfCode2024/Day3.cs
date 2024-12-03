using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public partial class Day3
{
    private static readonly Regex MulFinder = MulRegex();
    private static readonly Regex NumberFinder = NumberRegex();
    private static readonly Regex DoDontFinder = DoDontRegex();
    private static readonly string InputText = File.ReadAllText("Inputs/day3.txt");
    private const string Do = "do()";
    private const string Dont = "don't()";

    public static long Part1() =>
        MulFinder.Matches(InputText).Aggregate(0, (acc, current) =>
        {
            var numbers = NumberFinder.Matches(current.Value);
            var first = int.Parse(numbers[0].Value);
            var second = int.Parse(numbers[1].Value);
            return acc + first * second;
        });


    public static long Part2()
    {
        var enabled = true;
        return DoDontFinder.Matches(InputText).Aggregate(0, (acc, current) =>
        {
            switch (current.Value)
            {
                case var _ when !enabled && current.Value != Do:
                    return acc;
                case Do:
                    enabled = true;
                    return acc;
                case Dont:
                    enabled = false;
                    return acc;
                default:
                    var numbers = NumberFinder.Matches(current.Value);
                    var first = int.Parse(numbers[0].Value);
                    var second = int.Parse(numbers[1].Value);
                    return acc + first * second;
            }
        });

        //  return 0;
    }

    [GeneratedRegex(@"(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))", RegexOptions.Compiled)]
    private static partial Regex DoDontRegex();

    [GeneratedRegex(@"\d{1,3}", RegexOptions.Compiled)]
    private static partial Regex NumberRegex();
    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)", RegexOptions.Compiled)]
    private static partial Regex MulRegex();
    // foreach (Match match in matches)
    // {
    //     var numbers = NumberFinder.Matches(match.Value);
    //     var first = int.Parse(numbers[0].Value);
    //     var second = int.Parse(numbers[1].Value);
    //     InputText = InputText.Replace(match.Value, (first * second).ToString());
    // }
}