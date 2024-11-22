namespace ClassLibrary_Lab3
{
    public class State
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
}
