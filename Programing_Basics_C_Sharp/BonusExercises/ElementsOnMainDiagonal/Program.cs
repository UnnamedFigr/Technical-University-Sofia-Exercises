namespace ElementsOnMainDiagonal;

class Program
{
    static void Main(string[] args)
    {
        //Напишете функция, която приема като параметър двумерен масив от цели числа(квадратна матрица) и отпечатва на екрана само елементите, които се намират над главния диагонал, запазвайки стуктурата на матрицата

        //Примерни данни:
        //1 3 6 8
        //3 8 0 2
        //2 5 6 9
        //1 3 4 5

        //Резултат:
        //3 6 8
        //  0 2
        //    9
        Console.WriteLine("Enter the number of rows and cols in the matrix");
        int size = int.Parse(Console.ReadLine());
        GetMatrixElements(size, out int[,] matrix);
        PrintMatrix(matrix);
        Console.WriteLine("The elements above the diagonal are:\n");
        ShowElementsAboveDiagonal(matrix);
    }
    public static void GetMatrixElements(int size, out int[,] matrix)
    {
        matrix = new int[size, size];
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                Console.WriteLine($"Enter element on row {i + 1} | column {j + 1}");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    public static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("The matrix is: ");
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void ShowElementsAboveDiagonal(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (j > i)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                else
                {
                    Console.Write("  ");

                }
            }               
            Console.WriteLine();
        }
    }
}

