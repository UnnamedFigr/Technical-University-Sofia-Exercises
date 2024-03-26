namespace PrimeNumbersInterval;

class Program
{
    static void Main(string[] args)
    {
        //Напишете приложение, което отпечатва на екрана всички прости числа в
        //     интервала[M, N]. M и N се въвеждат от потребителя.
        //     Едно число е просто ако се дели без остатък само на 1 и на себе си.
        //    За да компилирате следващите задачи трябва да премахнете коментарите

        Console.WriteLine("Въведете стойността за M");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Въведете стойността за N");
        int n = int.Parse(Console.ReadLine());

        for(int i = m; i <= n; i++)
        {
            bool isPrime = true;
            int number = i;

            for(int j = 2; j < number && isPrime; j++)
            {
                if(number % j == 0)
                {
                    isPrime = false;
                }                
            }
            if(isPrime)
            {
                Console.WriteLine($"{number} е просто число.");
            }
        }
        Console.ReadLine();
    }
}

