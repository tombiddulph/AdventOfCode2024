namespace AdventOfCode2024;

public class Day2
{
    private static readonly IEnumerable<Report> Reports;

    static Day2()
    {
        Reports = File.ReadAllLines("Inputs/day2.txt").Select(line =>
            new Report(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()));
    }

    public static long Part1() => Reports.Count(x => x.Safe());

    public static long Part2() => Reports.Count(x => x.SafeWithDampener());

    private record Report(List<int> Levels)
    {
        public bool Safe() => IsSafe(Levels);

        public bool SafeWithDampener()
        {

            if (IsSafe(Levels))
            {
                return true;
            }

            for (int i = 0; i < Levels.Count; i++)
            {
                var copy = new List<int>(Levels);
                copy.RemoveAt(i);
                if (IsSafe(copy))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSafe(List<int> levels)
        {
            var allAscending = levels.Zip(levels.Skip(1), (a, b) => a < b).All(x => x);
            var allDescending = levels.Zip(levels.Skip(1), (a, b) => a > b).All(x => x);

            if (!allAscending && !allDescending)
            {
                return false;
            }

            for (var i = 0; i < levels.Count - 1; i++)
            {
                var delta = Math.Abs(levels[i] - levels[i + 1]);
                if (delta > 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}