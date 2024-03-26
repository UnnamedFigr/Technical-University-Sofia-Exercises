namespace DivisionWithoutPeriod;

class Program
{
    static void Main(string[] args)
    {
        //Напишете приложение, което намира сумата на първите N на брой цели
        //положителни числа, които се делят без остатък на числото M.N и M са цели
        //положителни числа, които се въвеждат от потребителя.
        bool correctInput = false;
        while (!correctInput)
        {
            Console.WriteLine("Въведете цяло положително число: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете делителя");
            int m = int.Parse(Console.ReadLine());
            int i = 1;
            int sum = 0;
            correctInput = n > m;
            if(!correctInput)
            {
                Console.WriteLine("Моля въведете правилни числа");
                continue;
            }
            do
            {
                if (i % m == 0)
                {
                    Console.WriteLine($"Числото {i} се дели на {m} без остатък");
                    sum += i;
                }
                i++;
            } while (i <= n);
            Console.WriteLine($"Сумата на 1 .. {n}, кратни на {m} е {sum}");
        }
        Console.ReadLine();
    }
}

