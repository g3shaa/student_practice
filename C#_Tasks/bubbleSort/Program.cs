using System;

public class Program
{
    // Функция за сортиране на масив по алгоритъм Bubble sort
    static int[] BubbleSort(int[] arr)
    {
        int len = arr.Length; // определяме дължината на масива
        // вложени цикли за сравняване на всички двойки елементи в масива
        for (int i = 0; i < len; i++) // първи цикъл за преминаване през всички елементи
        {
            for (int j = 0; j < len - 1; j++) // втори цикъл за сравняване на двойки елементи
            {
                if (arr[j] > arr[j + 1]) // проверка дали текущият елемент е по-голям от следващия
                {
                    int temp = arr[j]; // временна променлива за размяна на стойности на елементите
                    arr[j] = arr[j + 1]; // размяна на елементите
                    arr[j + 1] = temp; // размяна на елементите
                }
            }
        }
        return arr; // връща сортирания масив
    }

    // Тестване на Bubble sort
    public static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Масивът преди сортирането: " + string.Join(", ", arr));
        arr = BubbleSort(arr);
        Console.WriteLine("Масивът след сортирането: " + string.Join(", ", arr));
    }
}
