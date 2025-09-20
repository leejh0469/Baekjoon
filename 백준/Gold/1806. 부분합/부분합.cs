using System.Buffers;
using System.Security.AccessControl;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int N, S;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = input[0];
            S = input[1];
            
            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int left = 0;
            int right = 0;

            int min = int.MaxValue;
            int sum = input[left];

            while(left <= right && right < N)
            {
                if(sum >= S)
                {
                    int length = right - left + 1;
                    if (length < min)
                        min = length;

                    sum -= input[left++];
                }
                else
                {
                    if (right == N - 1)
                        break;
                    sum += input[++right];
                }
            }

            if(min == int.MaxValue)
                min = 0;

            Console.WriteLine(min);
        }
    }
}
