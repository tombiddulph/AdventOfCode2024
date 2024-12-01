namespace AdventOfCode2024;
using System.Collections;

public static class Day1
{
    private static readonly Locations locations;
    
    static Day1()
    {
        locations = File.ReadAllLines("inputs/day1.txt").Aggregate(new Locations(), (acc, current) =>
        {
            var split = current.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            acc.Left.Add(long.Parse(split[0]));
            acc.Right.Add(long.Parse(split[1]));
            return acc;
        });
    }
    
    
    public static long Part1() => locations.Sort().Distance();

    public static long Part2() => locations.Similarity();

    class Locations : IEnumerable<(long left, long right)>
    {
        public List<long> Left { get; } = [];
        public List<long> Right { get; } = [];

        public Locations Sort()
        {
            Left.Sort();
            Right.Sort();
            return this;
        }

        public long Similarity() => Left.Aggregate(0L, (acc, current) => acc + current * Right.Count(x => x == current));

        public long Distance() => this.Aggregate(0L, (acc, current) => acc + Math.Abs(current.left - current.right));

        public IEnumerator<(long, long)> GetEnumerator() => Left.Select((t, i) => (t, Right[i])).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

