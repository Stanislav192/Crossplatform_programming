namespace ClassLibrary_Lab5
{
    public class Lab2
    {
        public static string GoLab2(string userInput)
        {
            try
            {
                // Перевірка, чи введено числове значення
                if (!int.TryParse(userInput, out int n) || n < 1)
                {
                    return "Invalid input. Please enter a positive integer.";
                }

                // Виклик основної функції для обчислення
                int result = CountStrings(n);

                return $"The number of valid strings for N = {n} is {result}.";
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

        public static int CountStrings(int n)
        {
            if (n < 1 || n > 1000)
            {
                return 0;
            }

            int[] dp = new int[n + 1];

            dp[0] = 1; 
            dp[1] = 2; 


            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}