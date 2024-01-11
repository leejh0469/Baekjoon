using System.Text;
internal class Program
{
    static void DFS(int i, int len)
    {
        list.Add(arr[i]);
        if (len >= length)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < list.Count; j++)
            {
                sb.Append(list[j] + " ");
            }
            Console.WriteLine(sb.ToString());
            list.RemoveAt(list.Count - 1);
            return;
        }
        for (int j = 0; j < n; j++)
        {
            if (!list.Contains(arr[j]))
                DFS(j, len + 1);
        }
        list.RemoveAt(list.Count - 1);
    }
    static int n;
    static int length;
    static List<int> list = new List<int>();
    static int[] arr;
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        n = input[0];
        length = input[1];

        arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse) ;
        Array.Sort(arr);

        int len = 0;
        for (int i = 0; i < n; i++)
        {
            DFS(i, len + 1);
        }
    }
}