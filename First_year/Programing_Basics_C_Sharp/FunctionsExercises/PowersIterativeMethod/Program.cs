namespace PowersIterativeMethod;

class Program
{
    static void Main(string[] args)
    {
        //Напишете итеративна функция PowerI, който изчислява стойнста на числото m,
        //повдигнато на степен n. Извикайте функцията с примерни параметри.

        Console.WriteLine("Enter the number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the power: ");
        int pow = int.Parse(Console.ReadLine());
        Console.WriteLine(PowerI(num, pow));
        Console.ReadLine();

    }

    static long PowerI(int number, int power)
    {
        long result = number;
        for(int i = 1; i < power; i++)
        {
            result *= number;
        }
        return result;
    }
}

