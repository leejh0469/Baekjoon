namespace ConsoleApp1
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                int A = input[0];
                int B = input[1];

                string[] s = new string[10000];
                bool[] visited = new bool[10000];
                int resister = 0;

                Queue<int> q = new Queue<int>();
                q.Enqueue(A);
                visited[A] = true;

                while (q.Count > 0)
                {
                    int x = q.Dequeue();

                    if (x == B)
                        break;

                    int cal;

                    cal = (x * 2) % 10000;
                    if (!visited[cal])
                    {
                        q.Enqueue(cal);
                        visited[cal] = true;
                        s[cal] = s[x] + 'D';
                    }

                    if (x == 0)
                        cal = 9999;
                    else
                        cal = x - 1;

                    if (!visited[cal])
                    {
                        q.Enqueue(cal);
                        visited[cal] = true;
                        s[cal] = s[x] + 'S';
                    }

                    int[] d = new int[4];

                    int temp = x;
                    int div = 10;

                    for(int j = 0; j < 4; j++)
                    {
                        d[j] = temp % div;
                        temp /= div;
                    }

                    cal = ((d[2] * 10 + d[1]) * 10 + d[0]) * 10 + d[3];

                    if (!visited[cal])
                    {
                        q.Enqueue(cal);
                        visited[cal] = true;
                        s[cal] = s[x] + 'L';
                    }

                    cal = ((d[0] * 10 + d[3]) * 10 + d[2]) * 10 + d[1];
                    if (!visited[cal])
                    {
                        q.Enqueue(cal);
                        visited[cal] = true;
                        s[cal] = s[x] + 'R';
                    }
                }

                Console.WriteLine(s[B]);
            }
        }
    }
}
