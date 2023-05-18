using System;

namespace BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи число в двоична бройна система: ");
            string binaryNumber = Console.ReadLine();

            int decimalNumber = ConvertBinaryToDecimal(binaryNumber);

            Console.WriteLine("Резултат: " + decimalNumber);
        }

        static int ConvertBinaryToDecimal(string binaryNumber)
        {
            int decimalNumber = 0;
            int power = 0;

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, power);
                }

                power++;
            }

            return decimalNumber;
        }
    }
}
