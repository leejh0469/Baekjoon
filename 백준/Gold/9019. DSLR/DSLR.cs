using System.Text;
using System.Collections.Generic;
using System;

// 백준 9019번: DSLR (최종 최적화)
internal class Program
{
    static void Main(string[] args)
    {
        var sb = new StringBuilder();
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int A = input[0];
            int B = input[1];

            // [최적화] 경로 추적을 위한 배열
            int[] parent = new int[10000];
            char[] command = new char[10000]; 
            bool[] visited = new bool[10000];
            
            Queue<int> q = new Queue<int>();
            q.Enqueue(A);
            visited[A] = true;
            // parent, command 배열의 시작점은 굳이 초기화할 필요 없음

            while (q.Count > 0)
            {
                int current = q.Dequeue();

                if (current == B) break; // 목표 도달 시 탐색 종료

                // 1. D 명령어
                int next = (current * 2) % 10000;
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    parent[next] = current; // 부모와
                    command[next] = 'D';    // 명령어를 기록
                }

                // 2. S 명령어
                next = (current == 0) ? 9999 : current - 1;
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    parent[next] = current;
                    command[next] = 'S';
                }

                // 3. L 명령어
                next = (current % 1000) * 10 + (current / 1000);
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    parent[next] = current;
                    command[next] = 'L';
                }

                // 4. R 명령어
                next = (current % 10) * 1000 + (current / 10);
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    parent[next] = current;
                    command[next] = 'R';
                }
            }

            // [최적화] 경로 역추적 단계
            var path = new StringBuilder();
            int trace = B;
            while (trace != A)
            {
                path.Append(command[trace]);
                trace = parent[trace];
            }
            
            // StringBuilder에 담긴 경로는 역순이므로 뒤집어줌
            string result = new string(path.ToString().ToCharArray().Reverse().ToArray());
            sb.AppendLine(result);
        }
        Console.Write(sb.ToString());
    }
}