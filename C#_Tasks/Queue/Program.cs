using System;
using System.Collections.Generic;

class Queue
{
    private List<object> items;

    public Queue()
    {
        items = new List<object>();
    }

    //добавя елемент накрая на опашката
    public void Enqueue(object element)
    {
        items.Add(element);
    }

    //връща елемента от началото на опашката без да го премахва 
    public object Dequeue()
    {
        if (IsEmpty())
        {
            return "Underflow";
        }

        object item = items[0];
        items.RemoveAt(0);

        return item;
    }

    //връща първия елемент в опашката, без да го премахва от нея
    public object Front()
    {
        if (IsEmpty())
        {
            return "No elements in Queue";
        }

        return items[0];
    }

    //проверява дали опашката е празна
    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    //извежда всички елементи в опашката последователно, като започва от първия елемент и завършва с последния
    public void PrintQueue()
    {
        string str = "";
        foreach (object item in items)
        {
            str += item + " ";
        }

        Console.WriteLine(str);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue queue = new Queue();

        Console.WriteLine(queue.IsEmpty()); // true

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.PrintQueue(); // "10 20 30"

        Console.WriteLine(queue.Front()); // 10

        Console.WriteLine(queue.Dequeue()); // 10

        queue.PrintQueue(); // "20 30"
    }
}
