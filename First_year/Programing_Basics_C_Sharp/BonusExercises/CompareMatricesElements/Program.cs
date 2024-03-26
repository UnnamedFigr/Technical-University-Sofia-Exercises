namespace CompareMatricesElements;

class Program
    {
        //Напишете функция, която сравнява две матрици от цели числа и връща резултат дали те са еднакви(дали съответните им елементи са еднакви по стойност)

        static void Main(string[] args)
        {
            int[,] firstMatrix = new int[,] { { 2, 3, 4 }, { 5, 6, 7 } };
            int[,] secondMatrix = new int[,] { { 2, 3, 4 }, { 5, 5, 7 } };
            if(MatrixEquality(firstMatrix, secondMatrix))
            {
                Console.WriteLine("Matrices are equal");
            }
            else
            {
                Console.WriteLine("Matrices are NOT equal");
            }
        }

        public static bool MatrixEquality(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) ||
                firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                return false;
            }
            int rows = firstMatrix.GetLength(0);
            int cols = firstMatrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (firstMatrix[i, j] != secondMatrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }


