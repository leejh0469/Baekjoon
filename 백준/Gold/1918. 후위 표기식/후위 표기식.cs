using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        if(stack.Count == 0)
                            stack.Push(input[i]);
                        else
                        {
                            while(stack.Count > 0)
                            {
                                if (stack.Peek() == '(')
                                    break;

                                if (GetPriority(input[i]) > GetPriority(stack.Peek()))
                                    break;
                                    
                                sb.Append(stack.Pop());
                            }

                            stack.Push(input[i]);
                        }
                        break;
                    case '(':
                        stack.Push(input[i]);
                        break;
                    case ')':
                        while(stack.Peek() != '(')
                        {
                            sb.Append(stack.Pop());
                        }
                        stack.Pop();
                        break;
                    default:
                        sb.Append(input[i]);
                        break;
                }
            }

            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());
        }

        public static int GetPriority(char c)
        {
            int priority = 0;

            switch (c)
            {
                case '+':
                case '-':
                    priority = 0;
                    break;
                case '*':
                case '/':
                    priority = 1;
                    break;
                case '(':
                case ')':
                    priority = 2;
                    break;
            }

            return priority;
        }
    }
}
