using System;

namespace task_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int positiveSum = 0;
            int positiveCount = 0;
            int countDivisibleBy3 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (number > 0)
                {
                    positiveSum += number;
                    positiveCount++;
                }
                if (number % 3 == 0)
                {
                    countDivisibleBy3++;
                }
            }

            Console.WriteLine(sum);
            if (positiveCount > 0)
            {
                int positiveAverage = positiveSum / positiveCount;
                Console.WriteLine(positiveAverage);
            }
            else
            {
                Console.WriteLine("No positive numbers.");
            }
            Console.WriteLine(countDivisibleBy3);

        }

    }
}