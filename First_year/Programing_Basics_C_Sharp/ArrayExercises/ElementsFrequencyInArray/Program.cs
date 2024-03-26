namespace ElementsFrequencyInArray;

class Program
{
    static void Main(string[] args)
    {
        // Функция, която отпечатва на екрана колко пъти се среща всеки елемент в даден масив
        Console.WriteLine("Въведете броя на елементите в масива");
        int n = int.Parse(Console.ReadLine());
        int[] array = GetValues(n);
        CountElements(array);
    }
    public static int[] GetValues(int length)
    {
        int[] array = new int[length];
        for(int i = 0; i < length; i++)
        {
            Console.WriteLine($"Стойност: {i + 1}");
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    public static void CountElements(int[] array)
    {
        int[] counter = new int[array.Length];
        int n = array.Length;
        for(int i = 0; i < n; i++)
        {
            if(counter[i] != -1)
            {
                counter[i] = 1;
                for(int j = i + 1; j < n; j++)
                {
                    if (array[i] == array[j])
                    {
                        counter[i]++;
                        counter[j] = -1;
                    }
                }
            }
        }
        for(int i = 0; i < n; i++)
        {
            if (counter[i] == 1)
            {
                Console.WriteLine($"Числото {array[i]} се среща {counter[i]} път");
            }
            else if (counter[i] > 1)
            {
                Console.WriteLine($"Числото {array[i]} се среща {counter[i]} пъти");
            }
        }
    }
}

