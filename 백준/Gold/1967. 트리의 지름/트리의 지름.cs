using System.Buffers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    public class Node
    {
        // 자기 부모 노드에 올라가는 비용
        public int value;

        public List<Node> children;

        public Node()
        {
            children = new List<Node>();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Node[] nodes = new Node[n];

            for(int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }

            int[] inputs;

            for(int i = 0; i < n - 1; i++)
            {
                inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int source = inputs[0] - 1;
                int target = inputs[1] - 1;
                int value = inputs[2];

                nodes[target].value = value;
                nodes[source].children.Add(nodes[target]);
            }

            int max = 0;

            dfs(nodes[0]);
            
            Console.WriteLine(max);

            void dfs(Node? root)
            {
                if (root.children.Count == 0)
                    return;


                for(int i = 0; i < root.children.Count; i++)
                {
                    dfs(root.children[i]);
                }
                
                root.children.Sort((Node a, Node b) => { return b.value.CompareTo(a.value); });

                root.value = root.children[0].value + root.value;

                if (root.children.Count >= 2 && root.children[0].value + root.children[1].value > max)
                {
                    max = root.children[0].value + root.children[1].value;
                }

                if(root.children.Count == 1 && root.children[0].value > max)
                {
                    max = root.children[0].value;
                }
            }

        }
    }
}


