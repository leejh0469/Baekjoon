using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    // Y, X 좌표를 간결하게 다루기 위한 record
    public record Vector(int Y, int X);

    internal class Program
    {
        // 우선순위에 맞게 상, 좌, 우, 하 순서로 탐색
        public static int[,] direction = { { -1, 0 }, { 0, -1 }, { 0, 1 }, { 1, 0 } };
        static int N;
        static int[,] graph;
        static int sharkSize = 2;
        static int eatCount = 0;
        static int totalTime = 0;
        static Vector sharkPos;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            graph = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < N; j++)
                {
                    graph[i, j] = input[j];
                    if (input[j] == 9)
                    {
                        sharkPos = new Vector(i, j);
                        graph[i, j] = 0; // 상어 위치는 빈 칸으로 처리
                    }
                }
            }

            // 시뮬레이션 시작
            while (true)
            {
                // 1. BFS를 통해 먹을 물고기 후보 찾기
                (Vector targetFish, int distance) = FindFish();

                // 2. 먹을 물고기가 없으면 종료
                if (targetFish == null)
                {
                    break;
                }

                // 3. 물고기 먹고, 상어 상태 업데이트
                EatFish(targetFish, distance);
            }

            Console.WriteLine(totalTime);
        }

        // BFS를 실행하여 가장 우선순위 높은 물고기 한 마리를 찾는 함수
        static (Vector, int) FindFish()
        {
            var distance = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    distance[i, j] = -1; // -1: 방문 안 함

            var q = new Queue<Vector>();
            q.Enqueue(sharkPos);
            distance[sharkPos.Y, sharkPos.X] = 0;

            var fishCandidates = new List<(Vector pos, int dist)>();

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nY = current.Y + direction[i, 0];
                    int nX = current.X + direction[i, 1];

                    // 맵 범위 체크, 방문 여부 체크, 지나갈 수 있는지 체크
                    if (nY < 0 || nY >= N || nX < 0 || nX >= N ||
                        distance[nY, nX] != -1 || graph[nY, nX] > sharkSize)
                    {
                        continue;
                    }

                    // 다음 칸으로 이동
                    distance[nY, nX] = distance[current.Y, current.X] + 1;
                    q.Enqueue(new Vector(nY, nX));

                    // 먹을 수 있는 물고기라면 후보에 추가
                    if (graph[nY, nX] > 0 && graph[nY, nX] < sharkSize)
                    {
                        fishCandidates.Add((new Vector(nY, nX), distance[nY, nX]));
                    }
                }
            }

            if (fishCandidates.Count == 0)
            {
                return (null, -1);
            }

            // LINQ를 사용하여 우선순위에 맞게 정렬 후 첫 번째 대상 반환
            var bestTarget = fishCandidates
                .OrderBy(f => f.dist)      // 1. 거리 순
                .ThenBy(f => f.pos.Y) // 2. Y좌표(높이) 순
                .ThenBy(f => f.pos.X) // 3. X좌표(왼쪽) 순
                .First();

            return (bestTarget.pos, bestTarget.dist);
        }

        // 찾은 물고기를 먹고 상어의 위치, 시간, 크기 등을 업데이트하는 함수
        static void EatFish(Vector targetFish, int distance)
        {
            // 시간 누적
            totalTime += distance;

            // 상어 위치 이동
            sharkPos = targetFish;

            // 물고기 먹기
            graph[targetFish.Y, targetFish.X] = 0;
            eatCount++;

            // 상어 성장
            if (eatCount == sharkSize)
            {
                sharkSize++;
                eatCount = 0;
            }
        }
    }
}