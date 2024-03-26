namespace Exam
{
    public class FirstProblem
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\kasap\\Documents\\Repositories\\Programing_Basics_C_Sharp\\Exam\\Exam\\numbers.txt";
            var ints = ReadArrayFromFile(path);  
            int scndHigh = SecondHighest(ints);
            Console.WriteLine(scndHigh);
            PrintMissingRanges(ints);
        }
        public static int[] ReadArrayFromFile(string path)
        {
            string content = File.ReadAllText(path);
            string[] elements = content.Split(',').ToArray();
            int[] numbers = new int[elements.Length];
            for(int i = 0 ; i < elements.Length; i++)
            {
                numbers[i] = int.Parse(elements[i]);
            }
            return numbers;
        }
        public static int SecondHighest(int[] array)
        {          
            int highest = array[1];
            int secondHighest = array[0];
            for(int i = 2; i < array.Length; i++)
            {
                if (array[i] > highest)
                {
                    secondHighest = highest;
                    highest = array[i];
                }
                else if (array[i] > secondHighest && array[i] != highest)
                {
                    secondHighest = array[i];
                }
            }
            return secondHighest;
        }
        public static void PrintMissingRanges(int[] array)
        {
            SortArray(array);
            for(int i = 0; i < array.Length - 1; i++) 
            {
                if ((array[i] + 1) == array[i + 1] - 1)
                {
                    Console.WriteLine(array[i] + 1);
                }

                else if(array[i] + 1 == array[i + 1]) { continue; }

                else
                {
                    Console.WriteLine($"{array[i] + 1} - {array[i + 1] - 1}");
                }
                
            }
        }
        public static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}