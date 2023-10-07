namespace NumberToLetterFromTheAlphabet;

class Program
{
    // Приложение, в което потребителят въвежда цяло число и на екрана се отпечатва буквата 
    // от българската азбука, която е с пореден номер равен на сумата на цифрите на числото
    static void Main(string[] args)
    {
        int userInput = int.Parse(Console.ReadLine());
        int sum = GetSum(userInput);
        Console.WriteLine("Сумата на числото е: " + sum);
        char letter = (char)('А' + sum - 1);
        Console.WriteLine($"Която отговоря на буквата: {letter}");
    }

    public static int GetSum(int userInput)
    {
        int sum = 0;
        while (userInput > 0)
        {
            int digit = userInput % 10;
            sum += digit;
            userInput /= 10;
        }
        if (sum > 30)
        {
            Console.WriteLine("Please enter a number which digits sum up to 30 in order to match the bulgaria alphabet");
        }
        return sum;
    }

}

