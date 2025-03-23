using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    public class Node
    {
        public int v;
        public int cost;

        public Node(int v, int cost)
        {
            this.v = v;
            this.cost = cost;
        }
    }

    internal class Program
    {
        public static int max = 0;
        public static int index;
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());

            List<Node>[] tree = new List<Node>[V + 1];

            for(int i = 1; i <= V; i++)
            {
                tree[i] = new List<Node>();
            }

            for (int i = 0; i < V; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int v = input[0];

                for (int j = 1; j < input.Length - 1; j += 2)
                {
                    tree[v].Add(new Node(input[j], input[j + 1]));
                }
            }

            bool[] visited = new bool[V + 1];

            visited[1] = true;
            DFS(tree, visited, 1, 0);

            for(int i = 0; i <= V; i++)
            {
                visited[i] = false;
            }
            max = 0;

            visited[index] = true;
            DFS(tree, visited, index, 0);

            Console.WriteLine(max);
        }

        public static void DFS(List<Node>[] tree, bool[] visited, int v, int diameter)
        {
            for(int i = 0; i < tree[v].Count; i++)
            {
                if (visited[tree[v][i].v])
                    continue;

                visited[tree[v][i].v] = true;
                DFS(tree, visited, tree[v][i].v, diameter + tree[v][i].cost);
                visited[tree[v][i].v] = false;
            }

            if(max < diameter)
            {
                max = diameter;
                index = v;
            }
        }
    }
}
