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

            string result = Program.Swap(input, 0, 2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Rearrange_EmptyInput_Output()
        {
            string input = "";
            StringBuilder result = new StringBuilder();

            Program.Rearrange(input, 0, result);

            Assert.Empty(result.ToString());
        }

        [Fact]
        public void Rearrange_TwoCharacterString()
        {
            StringBuilder result = new StringBuilder();
            string input = "AB";
            string expected = "AB" + Environment.NewLine + "BA" + Environment.NewLine;

            Program.Rearrange(input, 0, result);

            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void Rearrange_SingleCharacterString()
        {
            StringBuilder result = new StringBuilder();
            string input = "X";

            string expected = "X" + Environment.NewLine;
            Program.Rearrange(input, 0, result);

            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void TestFileReadAndWrite()
        {
            string inputFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab1", "INPUT.txt").Trim();
            string outputFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab1", "OUTPUT.txt");


            File.WriteAllText(inputFile, "ABC");

            Program.Main(new string[] { });


            string output = File.ReadAllText(outputFile).Trim();
            Assert.Contains("ABC", output);
            Assert.Contains("ACB", output);
            Assert.Contains("BAC", output);
            Assert.Contains("BCA", output);
            Assert.Contains("CAB", output);
            Assert.Contains("CBA", output);

            File.Delete(inputFile);
            File.Delete(outputFile);
        }
    }
}