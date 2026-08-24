using System;
using System.Collections.Generic;

class Program3_solution
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of intervals:");
        int n = int.Parse(Console.ReadLine()!);

        int[][] intervals = new int[n][];

        Console.WriteLine("Enter intervals:");

        for (int i = 0; i < n; i++)
        {
            intervals[i] = new int[2];

            Console.WriteLine("Enter start:");
            intervals[i][0] = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter end:");
            intervals[i][1] = int.Parse(Console.ReadLine()!);
        }

        int[][] result = Merge(intervals);

        Console.WriteLine("Merged intervals:");

        foreach (int[] interval in result)
        {
            Console.WriteLine(
                "[" + interval[0] + ", " + interval[1] + "]"
            );
        }
    }

    static int[][] Merge(int[][] intervals)
    {
        // Sort based on start value
        Array.Sort(intervals, (a, b) =>
            a[0].CompareTo(b[0]));

        List<int[]> result = new List<int[]>();

        int start = intervals[0][0];
        int end = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            int currentStart = intervals[i][0];
            int currentEnd = intervals[i][1];

            // Overlapping or touching intervals
            if (currentStart <= end)
            {
                end = Math.Max(end, currentEnd);
            }
            else
            {
                result.Add(new int[] { start, end });

                start = currentStart;
                end = currentEnd;
            }
        }

        // Add the last interval
        result.Add(new int[] { start, end });

        return result.ToArray();
    }
}