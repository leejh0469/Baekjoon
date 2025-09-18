using System.Buffers;
using System.Text;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] ary = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int left, right;
            int min = int.MaxValue;
            int minLeft = -1, minRight = -1;
            int currentAddValue;
            left = 0;
            right = N - 1;

            while(left < right)
            {
                currentAddValue = ary[left] + ary[right];

                if(Math.Abs(min) > Math.Abs(currentAddValue))
                {
                    minLeft = left;
                    minRight = right;
                    min = currentAddValue;
                }

                if(currentAddValue == 0)
                {
                    break;
                }

                if(currentAddValue < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            Console.WriteLine($"{ary[minLeft]} {ary[minRight]}");
        }
    }
}
