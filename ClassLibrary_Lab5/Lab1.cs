using System.Text;

namespace ClassLibrary_Lab5
{
    public class Lab1
    {
        public static string GoLab1(string input)
        {
            try
            {
                // Перевіряємо валідність вхідного рядка
                if (!IsStringOnlyLetters(input))
                {
                    throw new ArgumentException("Input contains non-letter characters.");
                }

                // Генеруємо всі можливі перестановки
                StringBuilder permutationsResult = new StringBuilder();
                Rearrange(input, 0, permutationsResult);

                // Повертаємо результат як рядок
                return permutationsResult.ToString().Trim();
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        public static bool IsStringOnlyLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        public static void Rearrange(string text, int indx, StringBuilder ress)
        {
            if (indx < 0 || indx >= text.Length)
            {
                throw new ArgumentOutOfRangeException("The index is not within acceptable limits");
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

                // Повертаємо рядок до попереднього стану
                text = Swap(text, indx, i);
            }
        }

        public static string Swap(string a, int i, int j)
        {
            try
            {
                // Перевірка, чи наші індекси в межах допустимого діапазону
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
