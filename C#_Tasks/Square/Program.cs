using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeaderRow(n);
            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddleRow(n);
            }
            PrintHeaderRow(n);
        }
        static void PrintHeaderRow(int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write("--");
            }
        }
        static void PrintMiddleRow(int n)
        {
            Console.WriteLine();
            Console.Write("-");
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.Write("-");
        }
    }
}