int[] array = { 1, 3, 4, 17, 19, 17, 83, 123, 133, 212 };
int ind = -1; // променено от -2 на -1
Console.WriteLine("Enter number for val=");
int val = int.Parse(Console.ReadLine()); // променено от Console.ReadLn() на Console.ReadLine() и добавена ключовата дума "int"
int left = 0, right = array.Length - 1; // променено от -2 на -1 и променено от -2 на -1
while (left <= right)
{
    int mid = (left + right) / 2;
    if (array[mid] == val)
    {
        ind = mid;
        break; // добавен break за да не продължава цикъла след като е намерен индексът
    }
    else if (array[mid] < val)
    {
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}
Console.WriteLine(ind); // променено от Console.WriteLn() на Console.WriteLine()