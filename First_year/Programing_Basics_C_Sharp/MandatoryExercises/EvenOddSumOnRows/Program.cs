namespace EvenOddSumOnRows;

class Program
{ 
    static void Main(string[] args)
    {
        string filePath = "/Users/ivan/Projects/Technical-University-Sofia-Exercises/Programing_Basics_C_Sharp/MandatoryExercises/EvenOddSumOnRows/matrix.txt";
        int[,] matrix = GetMatrix(filePath);
        PrintMatrix(matrix);
        int counter = 0;        
        int oddNumEvenCol = 0, evenNumOddRow = 0;
        Counter(matrix, ref evenNumOddRow, ref oddNumEvenCol);
        Console.WriteLine($"Сумата от четните по стойност елементи, намиращи се на нечетни редове е {evenNumOddRow}," +
            $" а сумата от нечетните по стойност елементи, намиращи се на четните стълбове на матрицата е {oddNumEvenCol}");
    }

    public static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("The matrix is:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine();
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
        }
        Console.WriteLine();
    }

    public static int[,] GetMatrix(string path)
    {
        string[] lines = File.ReadAllLines(path);
        int rows = int.Parse(lines[0]);
        int cols = int.Parse(lines[1]);
        
        int[,] matrix = new int[rows, cols];
        for(int i = 0; i < rows; i++)
        {
            int[] row = lines[i + 2].Split(new string[] {}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for(int j = 0; j < cols; j++)
            {

                matrix[i, j] = row[j];
            }
        }
        return matrix;
    }

    public static void Counter(int[,] matrix, ref int evenNumOddRow, ref int oddNumEvenColon)
    {
        int rowCounter = 1;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            int columnCounter = 1;
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if(rowCounter % 2 != 0 && matrix[i, j] % 2 == 0)
                {
                    evenNumOddRow += matrix[i, j];
                }
                if(columnCounter % 2 == 0 && matrix[i, j] % 2 != 0)
                {
                    oddNumEvenColon += matrix[i, j];
                }
                columnCounter++;
            }
            rowCounter++;
        }
    }
}

