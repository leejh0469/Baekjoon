internal class Program
{
    static void DFS(int i, int len)
    {
        list.Add(i);
        if(len >= length)
        {
            for(int j = 0; j < list.Count; j++)
            {
                Console.Write(list[j] + " ");
            }
            list.RemoveAt(list.Count - 1);
            return;
        }
        for(; i < n; i++)
        {
            DFS(i + 1, len + 1);
        }
        list.RemoveAt(list.Count-1);
    }
    static int n;
    static int length;
    static List<int> list = new List<int>();
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        n = input[0];
        length = input[1];

        int len = 0;
        for(int i = 0; i < n; i++)
        {
            DFS(i + 1, len + 1);
        }
    }
}