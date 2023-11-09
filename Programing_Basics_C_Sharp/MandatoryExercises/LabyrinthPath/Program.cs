namespace LabyrinthPath
{
    using System;

    using System.IO;



    class Program
    {

        public static void Main(string[] args)
        {

            int[,] labr;

            int startX, startY;

            int exitX, exitY;

            string path = "C:\\Users\\kasap\\Documents\\Repositories\\Programing_Basics_C_Sharp\\MandatoryExercises\\LabyrinthPath\\lab1.txt";
            using (var r = File.OpenText(path))
            {
                int n = int.Parse(r.ReadLine());

                labr = new int[n, n];

                startX = int.Parse(r.ReadLine());
                startY = int.Parse(r.ReadLine());
                exitX = int.Parse(r.ReadLine());
                exitY = int.Parse(r.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    var Vals = r.ReadLine().Split(' ');

                    for (int j = 0; j < n; j++)
                        labr[i, j] = int.Parse(Vals[j]);
                }
            }
            static bool SearchPath(int[,] labr, int currentX, int currentY, int exitX, int exitY)
            {
                if (currentX < 0 || currentX >= labr.GetLength(1) || currentY < 0 || currentY >= labr.GetLength(0) || labr[currentY, currentX] != 0)

                { return false; }

                if (currentX == exitX && currentY == exitY)
                {
                    Console.Write("{0}, {1} -> ", currentX, currentY);

                    return true;
                }

                labr[currentX, currentY] = 1;

                if (SearchPath(labr, currentX - 1, currentY, exitX, exitY))
                {
                    Console.Write("({0}, {1}) -> ", currentX, currentY);
                    return true;
                }
                if (SearchPath(labr, currentX + 1, currentY, exitX, exitY))
                {
                    Console.Write("({0}, {1}) -> ", currentX, currentY);
                    return true;
                }
                if (SearchPath(labr, currentX, currentY - 1, exitX, exitY))
                {
                    Console.Write("({0}, {1}) -> ", currentX, currentY);
                    return true;
                }

                if (SearchPath(labr, currentX, currentY + 1, exitX, exitY))
                {
                    Console.Write("({0}, {1}) -> ",
                        currentX, currentY);
                    return true;
                }
                labr[currentY, currentX] = 0;
                return false;

            }

        }

    }
}