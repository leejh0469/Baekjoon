using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // N이 2 이하일 경우, 전체 배열이 정답
            if (N <= 2)
            {
                Console.WriteLine(N);
                return;
            }

            int left = 0;
            int maxLength = 0;
            // 딕셔너리를 사용하여 현재 윈도우에 있는 숫자의 개수를 추적
            var counts = new Dictionary<int, int>();

            // right 포인터가 배열 끝까지 이동
            for (int right = 0; right < N; right++)
            {
                // 1. 윈도우 확장: right 포인터의 숫자를 윈도우에 추가
                int num = input[right];
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts.Add(num, 1);
                }

                // 2. 윈도우 축소: 윈도우 내 숫자의 종류가 2개를 초과하면, 2개가 될 때까지 left 포인터를 이동
                while (counts.Count > 2)
                {
                    int leftNum = input[left];
                    counts[leftNum]--;
                    if (counts[leftNum] == 0)
                    {
                        counts.Remove(leftNum);
                    }
                    left++;
                }

                // 3. 결과 갱신: 현재 유효한 윈도우의 길이로 최대 길이를 갱신
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            Console.WriteLine(maxLength);
        }
    }
}