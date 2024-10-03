namespace Lab3
{
    class State
    {
        public char[,] a = new char[2, 4];

        public static State Read(string[] lines, int startIndex)
        {
            if (lines.Length < startIndex + 2)
            {
                Console.WriteLine("Not enough lines in the file to read the state.");
            }

            State s = new State();
            for (int i = 0; i < 2; i++)
            {
                string line = lines[startIndex + i].Trim();
                if (line.Length != 4)
                {
                    Console.WriteLine("Each line must contain exactly 4 characters.");
                }
                for (int j = 0; j < 4; j++)
                {
                    s.a[i, j] = line[j];
                }
            }
            return s;
        }

        public State DeepCopy()
        {
            State copy = new State();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    copy.a[i, j] = this.a[i, j];
                }
            }
            return copy;
        }

        public State Shift(int di, int dj)
        {
            State next = this.DeepCopy();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (next.a[i, j] == '#')
                    {
                        int ni = i + di;
                        int nj = j + dj;
                        if (0 <= ni && ni < 2 && 0 <= nj && nj < 4)
                        {
                            char temp = next.a[i, j];
                            next.a[i, j] = next.a[ni, nj];
                            next.a[ni, nj] = temp;
                        }
                        return next;
                    }
                }
            }
            return next;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            State s = (State)obj;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (this.a[i, j] != s.a[i, j])
                        return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (char c in a)
            {
                hash = hash * 31 + c;
            }
            return hash;
        }
    }

    class Program
    {
        static void Main()
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab3", "INPUT.txt").Trim();
            string outputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Lab3", "OUTPUT.txt").Trim();

            try
            {
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

                //Алгоритм пошуку найкоротшого шляху
                var len = new Dictionary<State, int>();
                var q = new Queue<State>();

                len[start] = 0;
                q.Enqueue(start);

                int result = -1; 

                while (q.Count > 0)
                {
                    State cur = q.Dequeue();

                    if (cur.Equals(finish))
                    {
                        result = len[cur]; 
                        break;
                    }

                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            if (di * di + dj * dj == 1)
                            {
                                State next = cur.Shift(di, dj);
                                if (!len.ContainsKey(next))
                                {
                                    len[next] = len[cur] + 1;
                                    q.Enqueue(next);
                                }
                            }
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    if (result == -1)
                    {
                        writer.WriteLine("-1"); 
                    }
                    else
                    {
                        Console.WriteLine("Finished Result is written in OUTPUT" );
                        writer.WriteLine(result); 
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
