using System.Text;

namespace ConsoleApp2
{
    public struct Node
    {
        public int root;
        public int left;
        public int right;

        public Node(int root, int left, int right)
        {
            this.root = root;
            this.left = left;
            this.right = right;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] preorder = new int[10001];

            int k = 0;

            while (true)
            {
                string s = Console.ReadLine();

                if (s == null || s == "")
                    break;

                preorder[k++] = int.Parse(s);
            }

            StringBuilder sb = new StringBuilder();

            Divide(sb, preorder, 0, k);

            Console.WriteLine(sb.ToString());
        }

        public static void Divide(StringBuilder sb, int[] preorder, int start, int end)
        {
            if (start >= end)
                return;

            int i = 0;

            for(i = start + 1; i < end; i++)
            {
                if (preorder[start] < preorder[i])
                    break;
            }

            Divide(sb, preorder, start + 1, i);
            Divide(sb, preorder, i, end);

            sb.AppendLine(preorder[start].ToString());
        }
    }
}
