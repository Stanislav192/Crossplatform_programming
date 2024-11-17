using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Lab4
{
    public class Lab3
    {
        public static void GoLab3(string inputFile, string outputFile)
        {
            try
            {
                // Перевірка наявності файлу
                if (!File.Exists(inputFile))
                    throw new FileNotFoundException($"Input file not found: {inputFile}");

                // Читання вхідних даних
                string[] lines = File.ReadAllLines(inputFile);

                if (lines.Length < 4)
                    throw new Exception("The input file must contain at least 4 lines (2 for the initial state and 2 for the final state).");

                // Створення початкового та кінцевого станів
                State start = State.Read(lines, 0);
                State finish = State.Read(lines, 2);

                // Запуск алгоритму BFS
                int result = FindShortestPath(start, finish);

                // Запис результату у вихідний файл
                File.WriteAllText(outputFile, result.ToString());
                Console.WriteLine("Result written to output file.");
            }
            catch (Exception ex)
            {
                // Обробка помилок
                File.WriteAllText(outputFile, "Error: " + ex.Message);
            }
        }

        public static int FindShortestPath(State start, State finish)
        {
            var len = new Dictionary<State, int>();
            var q = new Queue<State>();

            len[start] = 0;
            q.Enqueue(start);

            while (q.Count > 0)
            {
                State cur = q.Dequeue();

                if (cur.Equals(finish))
                {
                    return len[cur];
                }

                // Генерація сусідніх станів
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

            return -1; // Якщо шлях не знайдено
        }
    }

    public class State
    {
        public char[,] a = new char[2, 4];

        public static State Read(string[] lines, int startIndex)
        {
            if (lines.Length < startIndex + 2)
                throw new Exception("Not enough lines in the file to read the state.");

            State s = new State();
            for (int i = 0; i < 2; i++)
            {
                string line = lines[startIndex + i].Trim();
                if (line.Length != 4)
                    throw new Exception("Each line must contain exactly 4 characters.");

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
