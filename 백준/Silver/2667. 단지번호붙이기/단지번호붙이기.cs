internal class Program
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] map = new int[n, n];
        int[,] isVisit = new int[n, n];
        int count = 0;
        List<int> list = new List<int>();

        for(int i = 0; i <n; i++)
        {
            string inputs = Console.ReadLine();
            for(int j = 0; j < inputs.Length; j++)
            {
                map[i, j] = inputs[j] - '0';
            }
        }

        int x;
        int y;
        int[] xDirc = { 1, 0, -1, 0 };
        int[] yDirc = { 0, -1, 0, 1 };

        Queue<Pair<int, int>> q = new Queue<Pair<int, int>>();

        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if (map[i, j] == 1 && isVisit[i, j] == 0)
                {
                    isVisit[i, j] = 1;
                    q.Enqueue(new Pair<int, int>(i, j));
                    count++;
                    int countN = 1;
                    while(q.Count > 0)
                    {
                        Pair<int, int> p = q.Dequeue();
                        for(int k = 0; k < 4; k++)
                        {
                            x = p.First + xDirc[k];
                            y = p.Second + yDirc[k];

                            if ((x < 0 || x >= n) || (y < 0 || y >= n))
                                continue;
                            if (isVisit[x, y] == 0 && map[x, y] == 1)
                            {
                                isVisit[x, y] = 1;
                                q.Enqueue(new Pair<int, int>(x, y));
                                countN++;
                            }
                        }
                    }
                    list.Add(countN);
                }
            }
        }

        Console.WriteLine(count);
        list.Sort();
        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
    }
}