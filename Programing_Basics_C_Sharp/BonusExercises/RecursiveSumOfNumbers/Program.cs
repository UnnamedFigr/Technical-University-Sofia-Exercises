namespace RecursiveSumOfNumbers;

class Program
{
    static void Main(string[] args)
    {
        //Напишете рекурсивна функция,
        //която намира сумата на първите n
        //естествени числа, където n се определя от потребителя
        Console.WriteLine("Въведете до кое число искате да се намери сумата:");
        int n = int.Parse(Console.ReadLine());
        int sum = 0; 
        RecursiveSum(n, ref sum);
        Console.WriteLine($"The sum is: {sum}");

    }

    static void RecursiveSum(int n, ref int sum)
    {

        if(n > 0)
        {
            sum += n;
            RecursiveSum(n - 1, ref sum);
        }
    }
}

