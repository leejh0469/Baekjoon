using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    public struct Node
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
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string bomb = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for(int i = s.Length - 1; i >= 0; i--)
            {
                stack.Push(s[i]);

                if(stack.Count >= bomb.Length)
                {
                    if(stack.Peek() == bomb[0])
                    {
                        string check = "";

                        for(int j = 0; j < bomb.Length; j++)
                        {
                            check += stack.Pop();
                        }

                        if(check != bomb)
                        {
                            for(int j = bomb.Length - 1; j >= 0; j--)
                            {
                                stack.Push(check[j]);
                            }
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if(stack.Count > 0)
            {
                while(stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }
            }
            else
            {
                sb.Append("FRULA");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
