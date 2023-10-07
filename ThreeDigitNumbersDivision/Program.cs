namespace ThreeDigitNumbersDivision;

class Program
{
    static void Main(string[] args)
    {
        int number;
        int cnt = 0;
        for (int i= 100; i <= 999; i++)
        {
            int sum = 0;
            number = i;
            while (number > 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }
            if (i % sum == 0)
            {
                Console.WriteLine(i);
                cnt++;
            }
        }
        Console.WriteLine("Общият брой на числата е: " + cnt);
    }
}

