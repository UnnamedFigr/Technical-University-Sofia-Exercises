namespace PrimeNumber;

class Program
{
    //Напишете функция isPrime, която определя дали дадено число е просто

    static void Main(string[] args)
    {
        Console.WriteLine("Въведете 0 за да спрете цикъла");
       
        while(true)
        {
            Console.WriteLine("Въведете число:");

            int number = int.Parse(Console.ReadLine());

            if (isPrime(number))
            {
                Console.WriteLine(number + " is a prime number");
            }
            else
                Console.WriteLine(number + " is NOT a prime number");

            if (number == 0)
                break;
        }
    }
    
    static bool isPrime(int number)
    {
        if(number < 2)
        {
            return false;
        }

        for(int i = 2; i <= Math.Sqrt(number); i++)
        {
            if(number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

