namespace ExercisesLoops;

class Program
{
    static void Main(string[] args)
    {
        // Въвеждане на цяла стойност от потребител, организирана в цикъл,
        // който се изпълнява докато потребителя не въведе валидна целочислина стойност
        int n;
        bool ok;
        do
        {
            Console.WriteLine("Моля, въведете цяло число");

            ok = int.TryParse(Console.ReadLine(), out n);
            if (ok)
                Console.WriteLine(n);
            else
                Console.WriteLine("Не сте въвел цяло число");
        } while (!ok);
    }
}

