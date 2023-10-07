namespace DoWhileStatement;

class Program
{
    static void Main(string[] args)
    {
        int digitsSum = 0;
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            var isDigit = key.KeyChar >= '0' && key.KeyChar <= '9';
            if (isDigit)
            {
                digitsSum += key.KeyChar - '0';
            }
        } while (key.KeyChar != 13);
        Console.WriteLine();
        Console.WriteLine(digitsSum);
        Console.ReadLine();
    }
}