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
        public void TestFileReadAndWrite()
        {
            string inputFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab1", "INPUT.txt").Trim();
            string outputFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab1", "OUTPUT.txt");

            Console.WriteLine("Writing 'ABC' to input file: " + inputFile);
            File.WriteAllText(inputFile, "ABC");

            Console.WriteLine("Calling Program.Main()...");
            Program.Main(new string[] { });

            string output = File.ReadAllText(outputFile).Trim();
            Console.WriteLine("Output from output file: " + output);

            string[] expectedOutputs = { "ABC", "ACB", "BAC", "BCA", "CAB", "CBA" };
            foreach (var expected in expectedOutputs)
            {
                Console.WriteLine($"Checking if output contains {expected}...");
                Assert.Contains(expected, output);
            }

            Console.WriteLine("All permutations are found in the output. Test passed!");

            Console.WriteLine("Deleting input and output files...");
            File.Delete(inputFile);
            File.Delete(outputFile);
        }

    }
}