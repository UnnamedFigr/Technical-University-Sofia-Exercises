namespace TransponateMatrix;

class Program
{
    static void Main(string[] args)
    {
        //Функция, която транспонира дадена матрица и като резултат връща нова транспонирана матрица
        GetMatrixValues(out int[,] matrix);
        PrintMatrix(matrix);
        var tmatrix = TransponateMatrix(matrix);
        Console.WriteLine("\nThe matrix after being transosed: ");
        PrintMatrix(tmatrix);
        
    }
    public static void GetMatrixValues(out int[,] matrix)
    {
        Console.WriteLine("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        matrix = new int[rows, cols];

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Console.WriteLine($"Row {i + 1} || Column {j + 1}");
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
    public static int[,] TransponateMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] tmatrix = new int[cols, rows];
        for(int i = 0; i < cols; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                tmatrix[i, j] = matrix[j, i];
            }
        }
        return tmatrix;
    }
}

