using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var phoneBook = new Dictionary<string, int>();

        while (true)
        {
            var line = Console.ReadLine().Split();
            // if (input == "END") break;

            switch (line[0])
            {

                case "A":
                    {
                        phoneBook.Add(line[1], int.Parse(line[2]));
                        break;
                    }
                case "S":
                    {
                        if (phoneBook.ContainsKey(line[1]))
                        {
                            Console.WriteLine($"{line[1]} -> {phoneBook[line[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {line[1]} does not exist.");
                        }
                        break;
                    }
                case "END":
                    {
                        return;
                    }
                default:
                    break;

            }
        }
    }
}