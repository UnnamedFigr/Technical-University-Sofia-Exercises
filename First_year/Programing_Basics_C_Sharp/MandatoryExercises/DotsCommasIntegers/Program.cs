namespace DotsCommasIntegers;

class Program

{

    static void Main(string[] args)

    {

        Console.WriteLine("Write your file name: ");

        string fileName = Console.ReadLine();



        int dots = 0;

        int commas = 0;

        int nums = 0;



        using (StreamReader reader = new StreamReader($"/Users/ivan/Projects/Technical-University-Sofia-Exercises/Programing_Basics_C_Sharp/MandatoryExercises/DotsCommasIntegers/{fileName}.txt"))

        {

            int ch;

            while ((ch = reader.Read()) != -1)

            {
                char c = (char)ch;

                if (c == '.')

                {

                    dots++;

                }

                else if (c == ',')

                {

                    commas++;

                }

                else if (char.IsDigit(c))

                {

                    while ((ch = reader.Peek()) != -1 &&

                        char.IsDigit((char)ch))

                    {

                        reader.Read();

                    }

                    nums++;

                }

            }
        }

        Console.WriteLine("The dots are: {0}\n", dots);

        Console.WriteLine("The commas are: {0}\n", commas);

        Console.WriteLine("The numbers are: {0} \n", nums);

    }

}