class Program
{
    static void Main(string[] args)
    {
        //Напише функция, която намира най-малката стойност от всеки ред на двумерен целочислен масив

        Console.WriteLine("Enter number of rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns:");
        int cols = int.Parse(Console.ReadLine());
        InputValues(rows, cols, out int[,] matrix);
        PrintMatrix(matrix);
        int[] minValuesOnRows = FindMinValues(matrix);
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine($"The minimal value on row {i + 1} is {minValuesOnRows[i]}");
        }

        
    }
    static void InputValues(int rows, int cols, out int[,] matrix)
    {
        matrix = new int[rows, cols];

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Console.WriteLine($"Enter element on Row: {i + 1} Column: {j + 1}");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("The two dimensional array is:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine("\n");
        }
    }
    static int[] FindMinValues(int[,] matrix)
    {
        int[] minValues = new int[matrix.GetLength(0)];

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            minValues[i] = matrix[i, 0];
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if (minValues[i] > matrix[i, j])
                {
                    minValues[i] = matrix[i, j];
                }
            }
        }
        return minValues;
    }
}