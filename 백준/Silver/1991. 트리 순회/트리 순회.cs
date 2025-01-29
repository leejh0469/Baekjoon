using System.Buffers;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static StringBuilder sb;

        static void Main(string[] args)
        {
            sb = new StringBuilder();

            int N = int.Parse(Console.ReadLine());

            Node[] nodes = new Node[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node();
            }

            for(int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                int rootIndex = char.Parse(input[0]) - 65;
                nodes[rootIndex].alpha = char.Parse(input[0]);

                if (char.Parse(input[1]) != '.')
                {
                    int leftChildIndex = char.Parse(input[1]) - 65;
                    nodes[rootIndex].SetLeftChild(nodes[leftChildIndex]);
                }
                if (char.Parse(input[2]) != '.')
                {
                    int rightChildIndex = char.Parse(input[2]) - 65;
                    nodes[rootIndex].SetRightChild(nodes[rightChildIndex]);
                }
            }

            Preorder(nodes[0]);
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Inorder(nodes[0]);
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Postorder(nodes[0]);
            Console.WriteLine(sb.ToString());
            sb.Clear();

            void Preorder(Node? root)
            {
                if (root == null)
                    return;

                sb.Append(root.alpha);
                Preorder(root.leftChild);
                Preorder(root.rightChild);
            }
            
            void Inorder(Node? root)
            {
                if (root == null)
                    return;

                Inorder(root.leftChild);
                sb.Append(root.alpha);
                Inorder(root.rightChild);
            }

            void Postorder(Node? root)
            {
                if (root == null)
                    return;

                Postorder(root.leftChild);
                Postorder(root.rightChild);
                sb.Append(root.alpha);
            }
        }
    }

    public class Node
    {
        public char alpha;
        public Node? leftChild = null;
        public Node? rightChild = null;

        public void SetLeftChild(Node? leftChild)
        {
            this.leftChild = leftChild;
        }

        public void SetRightChild(Node? rightChild)
        {
            this.rightChild = rightChild;
        }
    }
}


