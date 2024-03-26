namespace TwoDimensionalArrayInput;

class Program
{
    static void Main(string[] args)
    {
        //Напишете функция, която въвежда елементите един целочислен двумерен масив

        Console.WriteLine("Enter the number of rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns:");
        int cols = int.Parse(Console.ReadLine());
        InputMatrix(rows, cols, out int[,] matrix);
        PrintMatrix(matrix);

    }
    public static void InputMatrix(int rows, int cols, out int[,] matrix)
    {
        matrix = new int[rows, cols];

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Console.WriteLine($"Enter element on Row:{i + 1} Column: {j + 1}");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    public static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("The two dimensional array is:");
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}

