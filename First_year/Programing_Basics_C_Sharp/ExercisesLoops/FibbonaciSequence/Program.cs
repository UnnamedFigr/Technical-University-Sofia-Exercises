namespace FibbonaciSequence;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Въведете до кой член искате да се отпечата редицата на Фибоначи");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Редицата е: \n");
        PrintFibonacciSequence(n);
        Console.ReadLine();

    }
    public static void PrintFibonacciSequence(int n)
    {
        int firstNumber = 0, secondNumber = 1;

        for(int i = 0; i < n; i++)
        {
            Console.Write(firstNumber + " ");

            int nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
        }
    }
}

