namespace NthElementsOfSequence;

public class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Въведете член между 0 и 100, който искате да намерите");
        int index = int.Parse(Console.ReadLine());
        int[] array = new int[100];
        array[0] = 2;
        array[1] = 4;
        array[2] = 6;

        if(index > 100 ||
            index < 0)
        {
            Console.WriteLine("Въведете правилно число!");
            return;
        }
        Console.WriteLine("This is the Iterative function:");
        Console.WriteLine($"The number with index: {index} is: {(long)Iterative(index, array)}");
        Console.WriteLine("This is the Recursive function:");
        Console.WriteLine(Recursive(index));
    }

    static int Iterative(int index, int[] array)
    {
        
        if(index < 3)
        {
            return array[index];
        }

        for(int i = 3; i <= index; i++)
        {
            array[i] = (3 * array[i - 3]) + (4 * array[i - 2]) + (7 * array[i - 1]);
        }

        return array[index];
    }

    static int Recursive(int index)
    {
        switch(index)
        {
            case 0:
                return 2;                
            case 1:
                return 4;
            case 2:
                return 6;
            default:
                return 3 * Recursive(index - 3) + 4 * Recursive(index - 2) + 7 * Recursive(index - 1);
        }
    }
}