using System;

public class BinarySearchExample
{
    public static int BinarySearch(int[] arr, int x)
    {
        // Инициализиране на началните и крайните индекси на масива
        int start = 0;
        int end = arr.Length - 1;

        // Докато интервалът, в който се предполага, че се намира x, не бъде съкратен до един елемент или x не бъде намерен
        while (start <= end)
        {
            // Изчисляване на средния индекс
            int mid = (start + end) / 2;
            // Ако x е намерен на mid индекса, връща mid
            if (arr[mid] == x)
            {
                return mid;
                // Ако x е по-голямо от елемента на mid индекса, продължава да търси в дясната половина на масива
            }
            else if (arr[mid] < x)
            {
                start = mid + 1;
                // Ако x е по-малко от елемента на mid индекса, продължава да търси в лявата половина на масива
            }
            else
            {
                end = mid - 1;
            }
        }

        // x не е намерен в масива
        return -1;
    }

    public static void Main()
    {
        // Инициализиране на масив и елемент, който се търси
        int[] arr = { 1, 3, 5, 7, 9 };
        int x = 5;

        // Търсене на x в масива arr
        int result = BinarySearch(arr, x);

        // Ако x не е намерен в масива, извежда съобщение в конзолата
        if (result == -1)
        {
            Console.WriteLine(x + " не е намерен в масива.");
            // Ако x е намерен в масива, извежда съобщение за неговата позиция
        }
        else
        {
            Console.WriteLine(x + " е намерен на позиция " + result + " в масива.");
        }
    }
}
