using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbsHeap maxHeap = new AbsHeap();
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(Console.ReadLine());

            for(int i = 0; i< N; i++)
            {
                int command = int.Parse(Console.ReadLine());

                if(command == 0)
                {
                    sb.AppendLine(maxHeap.Pop().ToString());
                }
                else
                {
                    maxHeap.Insert(command);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }

    public class AbsHeap
    {
        public int[] array = new int[100001];
        public int heapSize = 0;

        bool IsHighPriority(int a, int b)
        {
            if (Math.Abs(a) < Math.Abs(b))
            {
                return true;
            }
            else if (Math.Abs(a) == Math.Abs(b))
            {
                return (a < b) ? true : false;
            }
            else
                return false;
        }

        public void Insert(int value)
        {
            int i = ++heapSize;

            while (i != 1 && IsHighPriority(value, array[i/2]))
            {

                array[i] = array[i / 2];
                i /= 2;
            }

            array[i] = value;
        }

        public int Pop()
        {
            if (heapSize == 0)
                return 0;

            int value = array[1];

            int temp = array[heapSize--];

            int parent = 1;
            int child = 2;

            while(child <= heapSize)
            {
                if (child < heapSize && IsHighPriority(array[child + 1], array[child]))
                {
                    child += 1;
                }

                if (IsHighPriority(temp, array[child]))
                {
                    break;
                }

                array[parent] = array[child];
                parent = child;
                child = child * 2;
            }

            array[parent] = temp;

            return value;
        }
    }
}