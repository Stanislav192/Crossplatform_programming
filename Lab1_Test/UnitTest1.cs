using System.Text;
using Lab1;

namespace Lab1_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Swap_Characters()
        {
            string input = "ABC";
            string expected = "CBA";

            Console.WriteLine("Swap method : swap characters in " + input);
            Console.WriteLine("Expected output : " + expected);

            string result = Program.Swap(input, 0, 2);
            Console.WriteLine("Actual output : " + result);

            Assert.Equal(expected, result);

            if (result == expected)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
            Console.WriteLine();
        }


        [Fact]
        public void Rearrange_EmptyInput_Output()
        {
            string input = "";
            StringBuilder result = new StringBuilder();

            Console.WriteLine("Rearrange method: Empty input test");
            Console.WriteLine("Input: \"" + input + "\"");
            Console.WriteLine("Expected output: \"\"");

            Program.Rearrange(input, 0, result);

            string output = result.ToString();
            Console.WriteLine("Actual output: \"" + output + "\"");

            Assert.Empty(output);

            if (string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
            Console.WriteLine();
        }

        [Fact]
        public void Rearrange_TwoCharacterString()
        {
            string input = "AB";
            string expected = "AB" + Environment.NewLine + "BA" + Environment.NewLine;
            StringBuilder result = new StringBuilder();

            Console.WriteLine("Rearrange method: input string = " + input);
            Console.WriteLine("Expected output:");
            Console.WriteLine(expected);

            Program.Rearrange(input, 0, result);

            Assert.Equal(expected, result.ToString());

            if (result.ToString() == expected)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
            Console.WriteLine();
        }

        [Fact]
        public void Rearrange_SingleCharacterString()
        {
            string input = "X";
            StringBuilder result = new StringBuilder();
            string expected = "X" + Environment.NewLine;

            Console.WriteLine("Rearrange method: single character string test, input: " + input);
            Console.WriteLine("Expected output: " + expected);

            Program.Rearrange(input, 0, result);

            Assert.Equal(expected, result.ToString());

            if (result.ToString() == expected)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

            Console.WriteLine();
        }


        [Fact]
        public void Rearrange_RepeatedCharactersString()
        {
            string input = "AAB";
            StringBuilder result = new StringBuilder();
            string expectedOutput = "AAB" + Environment.NewLine + "ABA" + Environment.NewLine +
                                    "AAB" + Environment.NewLine + "ABA" + Environment.NewLine +
                                    "BAA" + Environment.NewLine + "BAA" + Environment.NewLine;

            Console.WriteLine("Rearrange method: Test string with repeated characters " + input);
            Console.WriteLine("Expected output:");
            Console.WriteLine(expectedOutput);

            Program.Rearrange(input, 0, result);
            
            Assert.Equal(expectedOutput, result.ToString());

            if (result.ToString() == expectedOutput)
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
            Console.WriteLine();
        }

    }
}