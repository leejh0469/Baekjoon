using System;
using System.IO;

namespace Baekjoon18111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 빠른 입력을 위해 StreamReader 사용
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] input = sr.ReadLine().Split();

            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int B = int.Parse(input[2]);

            int[,] ground = new int[N, M];
            int minHeight = 257;
            int maxHeight = -1;

            // 땅의 높이를 입력받으면서 최소/최대 높이를 찾음
            for (int i = 0; i < N; i++)
            {
                input = sr.ReadLine().Split();
                for (int j = 0; j < M; j++)
                {
                    int height = int.Parse(input[j]);
                    ground[i, j] = height;
                    if (height < minHeight) minHeight = height;
                    if (height > maxHeight) maxHeight = height;
                }
            }

            int minTime = int.MaxValue;
            int resultHeight = -1;

            // 가능한 모든 높이에 대해 완전 탐색 (Brute-force)
            // 최소 높이 ~ 최대 높이 범위만 탐색해도 충분
            for (int h = minHeight; h <= maxHeight; h++)
            {
                int blocksToAdd = 0;
                int blocksToRemove = 0;

                // 땅 전체를 **한 번만** 순회
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        int diff = ground[i, j] - h;

                        if (diff > 0) // 제거해야 할 블록
                        {
                            blocksToRemove += diff;
                        }
                        else if (diff < 0) // 추가해야 할 블록
                        {
                            blocksToAdd += -diff;
                        }
                    }
                }

                // 현재 인벤토리(B)와 제거할 블록으로 필요한 블록을 채울 수 있는지 확인
                if (B + blocksToRemove >= blocksToAdd)
                {
                    // 시간 계산: 제거는 2초, 추가는 1초
                    int currentTime = blocksToRemove * 2 + blocksToAdd;

                    // 더 짧은 시간이 걸리거나, 시간이 같으면서 높이가 더 높은 경우 갱신
                    if (currentTime <= minTime)
                    {
                        minTime = currentTime;
                        resultHeight = h;
                    }
                }
            }

            Console.WriteLine(minTime + " " + resultHeight);
        }
    }
}