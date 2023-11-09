namespace NecessaryLettersForWords
{
    class Program
    {
        static void Main()
        {
            string filePath = "C:\\Users\\kasap\\Documents\\Repositories\\Programing_Basics_C_Sharp\\MandatoryExercises\\NecessaryLettersForWords\\words.txt"; // Replace with your file path

            string[] words = ReadWordsFromFile(filePath);

            char[] minimalSet = FindMinimalLetterSet(words);

            Console.WriteLine("Minimal letter set: " + new string(minimalSet));
        }

        static string[] ReadWordsFromFile(string filePath)
        {
            string[] words = null;

            try
            {
                words = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading from the file: " + e.Message);
            }

            return words;
        }

        static char[] FindMinimalLetterSet(string[] words)
        {
            string distinctLetters = "";
            int[] maxOccurrences = new int[Char.MaxValue + 1]; 

            foreach (string word in words)
            {
                int[] occurrences = new int[Char.MaxValue + 1];

                foreach (char letter in word)
                {
                    occurrences[letter]++;
                }

                for (int i = 0; i < occurrences.Length; i++)
                {
                    if (occurrences[i] > maxOccurrences[i])
                    {
                        maxOccurrences[i] = occurrences[i];
                    }
                }
            }

            for (int i = 0; i < maxOccurrences.Length; i++)
            {
                if (maxOccurrences[i] > 0)
                {
                    char letter = (char)i;

                    for (int j = 0; j < Math.Min(2, maxOccurrences[i]); j++) 
                    {
                        distinctLetters += letter;
                    }
                }
            }

            return distinctLetters.ToCharArray();
        }
    }
}