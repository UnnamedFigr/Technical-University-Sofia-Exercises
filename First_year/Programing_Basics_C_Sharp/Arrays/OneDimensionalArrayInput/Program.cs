namespace OneDimensionalArrayInput;

class Program
{
    static void Main(string[] args)
    {
        //Напишете функция, която въвежда елементите един целочислен едномерен масив
        Console.WriteLine("Enter how many numbers are you going to input: ");
        int n = int.Parse(Console.ReadLine());
        int[] integerArray = new int[n];
        InputValues(integerArray);
        PrintArray(integerArray);
    }
    public static int[] InputValues(int[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
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

