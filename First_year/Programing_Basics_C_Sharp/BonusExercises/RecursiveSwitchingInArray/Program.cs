namespace RecursiveSwitchingInArray;

class Program
{
    static void Main(string[] args)
    {
        //Напишете рекурсивна функция, която размества елементите на едномерен
        //масив от цели числа, като първият и последният разменят местата си,
        //вторият предпоследният разменят местата си и така нататък,
        //т.е.обръща елементите на масива в обратен ред
        Console.WriteLine("The array before being reverted:");
        int[] array = new int[5] { 1, 2, 3, 4, 5 };
        PrintArray(array);

        RecursiveSwitch(0, array.Length - 1, array);
        Console.WriteLine("The array after being reverted:");
        PrintArray(array);
        Console.ReadLine();

    }
    public static void RecursiveSwitch(int start, int end, int[] array)
    {
        if(start < end)
        {
            int temp = array[start];
            array[start] = array[end];
            array[end] = temp;
            RecursiveSwitch(start + 1, end - 1, array); 
        }
    }
    public static void PrintArray(int[] array)
    {
        Console.WriteLine();
        for(int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

