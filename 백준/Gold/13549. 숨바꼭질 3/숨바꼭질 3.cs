namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int N = input[0];
            int K = input[1];

            int[] time = new int[100001];
            bool[] isVisit = new bool[100001];

            Queue<int> q = new Queue<int>();

            q.Enqueue(N);
            isVisit[N] = true;

            while(q.Count > 0)
            {
                int n = q.Dequeue();

                if(n == K)
                {
                    Console.WriteLine(time[n]);
                    break;
                }

                int next;

                next = n * 2;

                if (next >= 0 && next <= 100000 && !isVisit[next])
                {
                    q.Enqueue(next);
                    isVisit[next] = true;
                    time[next] = time[n];
                }

                next = n - 1;

                if(next >= 0 && next <= 100000 && !isVisit[next])
                {
                    q.Enqueue(next);
                    isVisit[next] = true;
                    time[next] = time[n] + 1;
                }

                next = n + 1;

                if (next >= 0 && next <= 100000 && !isVisit[next])
                {
                    q.Enqueue(next);
                    isVisit[next] = true;
                    time[next] = time[n] + 1;
                }
            }
        }
    }
}


