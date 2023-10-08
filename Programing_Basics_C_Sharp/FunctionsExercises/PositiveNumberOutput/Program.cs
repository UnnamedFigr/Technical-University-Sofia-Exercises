namespace PositiveNumberOutput;

class Program
{
    //Напишете функция, чрез която потребителят въвежда цяло положително число и връща това число като резултат.

    static void Main(string[] args)
    {
        Console.WriteLine("Моля въведете цяло положително число");
        int number = int.Parse(Console.ReadLine());
        if(OutputNumber(number) == 0)
        {
            Console.WriteLine("Не сте въвели правилно число!");
            return;
        }
        Console.WriteLine(OutputNumber(number) + " е числото, което сте въвели.");
        Console.ReadLine();
    }
    static int OutputNumber(int number)
    {
        if(number > 0)
        {
            return number;
        }
        return 0;
    }
}

