namespace ReversingArrayValues;

class Program
{
    static void Main(string[] args)
    {
        //Функция която обръща елементите на масив в обратен ред, и връща нов масив като не променя оригиналния масив

        Console.WriteLine("Въведете броя на елементите в масива");
        int n = int.Parse(Console.ReadLine());
        var intArray = GetValues(n);
        PrintArray(intArray);

        Console.WriteLine("The reversed:");
        int[] reversedArray = ReverseArray(intArray);
        PrintArray(reversedArray);
    }

    public static int[] GetValues(int n)
    {
        int[] array = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter element: {i + 1}");
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    public static int[] ReverseArray(int[] array)
    {
        int[] reversedArray = new int[array.Length];
        for(int i = 0; i < array.Length; i++)
        {
            reversedArray[i] = array[array.Length - i - 1];
        }
        return reversedArray;
    }

    public static void PrintArray(int[] array)
    {
        Console.WriteLine("The array is: \n");
        for(int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

