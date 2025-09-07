using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxHeap maxHeap = new MaxHeap();
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

    public class MaxHeap
    {
        public int[] array = new int[100001];
        public int heapSize = 0;

        public void Insert(int value)
        {
            int flag = ++heapSize;

            while(flag != 1 && value > array[flag / 2])
            {
                array[flag] = array[flag/2];
                flag /= 2;
            }

            array[flag] = value;
        }

        public int Pop()
        {
            if(heapSize == 0)
            {
                return 0;
            }

            int max = array[1];

            int temp = array[heapSize--];
            int parent = 1;
            int child = 2;

            while (child <= heapSize)
            {
                if (child < heapSize && array[child] < array[child + 1])
                    child++;

                if (temp >= array[child])
                    break;

                array[parent] = array[child];
                parent = child;
                child = child * 2;
            }

            array[parent] = temp;

            return max;
        }
    }
}