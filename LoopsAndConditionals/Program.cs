namespace LoopsAndConditionals;

class Program
{
    static void Main(string[] args)
    {

        //Приложение, в което потребителят въвежда 3 цели числа и на екрана се отпечатва най-голямото от тях

        Console.WriteLine("Въведете число А");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете число B");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете число C");
        int c = int.Parse(Console.ReadLine());

        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine($"A is the largest number ({a})");
            }
            else
            {
                Console.WriteLine($"C is the largest number ({c})");
            }
        }
        else
        {
            if (b > c)
            {
                Console.WriteLine($"B is the largest number ({b})");
            }
            else
            {
                Console.WriteLine($"C is the largest number ({c})");
            }

        }
    }
}
