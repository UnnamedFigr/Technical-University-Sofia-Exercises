namespace RecursiveSumInIntervalOfNumbers;

class Program
{
    static void Main(string[] args)
    {
        //Напишете рекурсивна функция, която намира сумата на
        //естествените числа в интервала[m, n] където m и n се определя от потребителя
        Console.Write("Въведете от кое число да започва интервала: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Въведете края на интервала: ");
        int m = int.Parse(Console.ReadLine());
        int sum = 0;
        SumInInterval(n, m, ref sum);
        Console.WriteLine($"The sum in the interval [{n}, {m}] is: {sum}");
    }

    static void SumInInterval(int n, int m, ref int sum)
    {
        if(m >= n)
        {
            sum += n;
            SumInInterval(n + 1, m, ref sum);
        }
    }
}

