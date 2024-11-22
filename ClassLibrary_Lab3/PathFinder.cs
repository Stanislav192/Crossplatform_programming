namespace ClassLibrary_Lab3
{
    public class PathFinder
    {
            public int FindShortestPath(State start, State finish)
            {
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

                return result;
            }
    }
}
