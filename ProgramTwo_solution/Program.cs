using System;
using System.Collections.Generic;

class Program2_solution
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of elements:");
        int n = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter array elements (space separated):");

        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("Enter K:");
        int k = int.Parse(Console.ReadLine()!);

        int result = FindKthLargest(nums, k);

        Console.WriteLine("The Kth largest element is " + result);
    }

    static int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> minHeap =
            new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);

            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}