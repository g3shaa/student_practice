using System;

class Program
{
    static void Main()
    {
        int number = 8;
        int result = Factorial(number);
        Console.WriteLine("The factorial of {0} is {1}.", number, result);
    }

    static int Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }
}
