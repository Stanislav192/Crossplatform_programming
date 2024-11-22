using ClassLibrary_Lab3;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab3", "INPUT.txt").Trim();
            string outputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab3", "OUTPUT.txt").Trim();

            try
            {
                // Читання вхідного файлу
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException($"File not found: {inputPath}");
                }

                string[] lines = File.ReadAllLines(inputPath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("The file is empty.");
                }

                if (lines.Length < 4)
                {
                    Console.WriteLine("The file must contain at least 4 lines (2 for the initial state and 2 for the final state).");
                }

                State start = State.Read(lines, 0);
                State finish = State.Read(lines, 2);

                PathFinder pathFinder = new PathFinder();
                int result = pathFinder.FindShortestPath(start, finish);

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    if (result == -1)
                    {
                        writer.WriteLine("-1");
                    }
                    else
                    {
                        Console.WriteLine("Finished Result is written in OUTPUT");
                        writer.WriteLine(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
