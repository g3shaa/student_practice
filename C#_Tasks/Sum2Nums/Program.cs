using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int length = Math.Max(arr1.Length, arr2.Length);
        int[] arrSum = new int[length];
        for (int i = 0; i < length; i++)
        {
            int sum = 0;
            if (i < arr1.Length) sum += arr1[i];
            if (i < arr2.Length) sum += arr2[i];
            arrSum[i] = sum;
        }
        Console.WriteLine(string.Join(" ", arrSum));

    }
}