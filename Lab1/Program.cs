﻿using System.Text;

namespace Lab1
{
    public class Program
    {
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



        public static void Main(string[] args)
        {

            string a = "AB";


            StringBuilder ress = new StringBuilder();
            Rearrange(a,0,ress);

            Console.WriteLine(ress.ToString());

        }
    }
}