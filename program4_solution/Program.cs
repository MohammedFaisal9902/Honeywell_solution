using System;

class Program4_solution
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of meetings:");
        int n = int.Parse(Console.ReadLine()!);

        int[][] intervals = new int[n][];

        Console.WriteLine("Enter meeting intervals:");

        for (int i = 0; i < n; i++)
        {
            intervals[i] = new int[2];

            Console.WriteLine("Enter start time:");
            intervals[i][0] = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter end time:");
            intervals[i][1] = int.Parse(Console.ReadLine()!);
        }

        int result = MinMeetingRooms(intervals);

        Console.WriteLine(
            "Minimum number of meeting rooms required: " + result
        );
    }

    static int MinMeetingRooms(int[][] intervals)
    {
        int n = intervals.Length;

        int[] startTimes = new int[n];
        int[] endTimes = new int[n];

        for (int i = 0; i < n; i++)
        {
            startTimes[i] = intervals[i][0];
            endTimes[i] = intervals[i][1];
        }

        Array.Sort(startTimes);
        Array.Sort(endTimes);

        int startPointer = 0;
        int endPointer = 0;

        int rooms = 0;
        int maxRooms = 0;

        while (startPointer < n)
        {
            // Meeting starts before another meeting ends
            if (startTimes[startPointer] < endTimes[endPointer])
            {
                rooms++;

                if (rooms > maxRooms)
                {
                    maxRooms = rooms;
                }

                startPointer++;
            }
            else
            {
                // Meeting has ended, room can be reused
                rooms--;
                endPointer++;
            }
        }

        return maxRooms;
    }
}