namespace PowersRecursiveMethod;

class Program
{
    static void Main(string[] args)
    {
        //Напишете рекурсивна функция PowerR, който изчислява стойнста на
        //числото m, повдигнато на степен n. Извикайте функцията с примерни параметри.
        int num = int.Parse(Console.ReadLine());
        int pow = int.Parse(Console.ReadLine());
        Console.WriteLine(RecursiveMethod(num, pow));
    }

    static int RecursiveMethod(int number, int power)
    {
        int result;
        switch(power)
        {
            case 0:
                result = 1;
                return result;
                break;
            case 1:
                result = number;
                return result;
                break;
            default:
                result = RecursiveMethod(number - 1, power - 1);
                break;
        }
        return result;
    }
}

