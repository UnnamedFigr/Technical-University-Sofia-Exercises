namespace SumOfRowsAndColumns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of rows ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        GetMatrixElements(rows, cols, out int[,] matrix);
        PrintMatrix(matrix);
        SumOfRowsAndCols(matrix);

    }
    public static void GetMatrixElements(int rows, int cols, out int[,] matrix)
    {
        matrix = new int[rows, cols];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Console.WriteLine($"Element on row {i + 1} | column {j + 1}");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    public static void PrintMatrix(int[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine();
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
        }
    }
    public static void SumOfRowsAndCols(int[,] matrix)
    {
        int[] matrixRowsSum = new int[matrix.GetLength(0)];
        int[] matrixColsSum = new int[matrix.GetLength(1)];

        for(int i = 0; i < matrix.GetLength(0); i++)
        {           
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixRowsSum[i] += matrix[i, j];                
            }        
        }

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrixColsSum[i] += matrix[j, i];

            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine($"The sum of Row {i + 1} is: {matrixRowsSum[i]}");
        }

        for(int k = 0; k < matrix.GetLength(1); k++)
        {
            Console.WriteLine($"The sum of Column {k + 1} is: {matrixColsSum[k]}");
        }
    }
}

