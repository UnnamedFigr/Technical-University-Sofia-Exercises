namespace MinValueInArray;

class Program
{
    static void Main(string[] args)
    {
        //Напишете функция, която намира най-малката стойност от едномерен целочислен масив
        Console.WriteLine("Enter the number of elements you want to input");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        GetValues(array);
        PrintArray(array);        
        Console.WriteLine("\nThe minimal value in the array is: " + Min(array));
    }
    static void GetValues(int[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static void PrintArray(int[] array)
    {
        Console.WriteLine("The array is: ");
        for(int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
    static int Min(int[] array)
    {
        int min = array[0];
        for(int i = 1; i < array.Length; i++)
        {
            if(min > array[i])
            {
                min = array[i];
            }
        }
        return min;
    }
}

