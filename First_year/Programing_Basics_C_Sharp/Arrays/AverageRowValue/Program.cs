namespace AverageRowValue;

class Program
{
    static void Main(string[] args)
    {
        //Напишете функция, която намира среднаритметичното на елементите на един двумерен масив
        Console.WriteLine("Enter number of rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns:");
        int cols = int.Parse(Console.ReadLine());
        InputValues(rows, cols, out int[,] matrix);
        PrintMatrix(matrix);
        double[] avgValues = FindAverageRowValue(matrix);
        for(int i = 0; i < avgValues.Length; i++)
        {
            Console.WriteLine($"The average value on row {i + 1} is: {avgValues[i]}");
        }
    }

    static void InputValues(int rows, int cols, out int[,] matrix)
    {
        matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
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
    static double[] FindAverageRowValue(int[,] matrix)
    {
        double[] averageValues = new double[matrix.GetLength(0)];
        int cols = matrix.GetLength(1);
        int rows = matrix.GetLength(0);

        for(int i = 0; i < rows; i++)
        {
            int[] rowValues = new int[matrix.GetLength(1)];
            for(int j = 0; j < cols; j++)
            {
                rowValues[j] = matrix[i, j];
            }
            averageValues[i] = (double)(SumRow(rowValues) / cols);
        }
        return averageValues;
    }
    static int SumRow(int[] matrixRow)
    {
        int sum = 0;
        for(int i = 0; i < matrixRow.Length; i++)
        {
            sum += matrixRow[i];
        }
        return sum;
    }
}

