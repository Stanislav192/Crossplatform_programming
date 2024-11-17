using System.Text;

namespace ClassLibrary_Lab4
{
    public class Lab1
    {
        public static void GoLab1(string inputFile, string outputFile)
        {
            try
            {
                // Читаємо вхідні дані
                string input = ReadInputData(inputFile);

                // Перевіряємо валідність вхідного рядка
                IsStringOnlyLetters(input);

                // Генеруємо всі можливі перестановки
                StringBuilder permutationsResult = new StringBuilder();
                Rearrange(input, 0, permutationsResult);

                // Записуємо результати у файл
                File.WriteAllText(outputFile, permutationsResult.ToString().Trim());

                Console.WriteLine($"Results have been successfully saved to {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static string ReadInputData(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"Input file not found: {inputFile}");
            }

            string input = File.ReadAllText(inputFile).Trim();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input string cannot be empty or null.");
            }
            return input;
        }

        public static bool IsStringOnlyLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        public static void Rearrange(string text, int indx, StringBuilder ress)
        {

            if (indx < 0 || indx >= text.Length)
            {
                Console.WriteLine("The index is not within acceptable limits");
            }

            if (indx == text.Length - 1)
            {
                ress.AppendLine(text);
                return;
            }

            for (int i = indx; i < text.Length; i++)
            {

                text = Swap(text, indx, i);

                Rearrange(text, indx + 1, ress);

                //Повертаємо рядок до попереднього стану
                text = Swap(text, indx, i);

            }
        }

        public static string Swap(string a, int i, int j)
        {
            try
            {
                //Перевірка, чи наші індекси в межах допустимого діапазону
                if (i < 0 || j < 0 || i >= a.Length || j >= a.Length)
                {
                    throw new IndexOutOfRangeException("Indexes should be within the length of the string.");
                }

                char[] charArr = a.ToCharArray();

                char temp = charArr[i];

                charArr[i] = charArr[j];

                charArr[j] = temp;

                return new string(charArr);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Error: {ex.Message}");
                return a;
            }
        }
    }
}
