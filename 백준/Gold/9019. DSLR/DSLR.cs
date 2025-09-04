using System.Text;

// 백준 9019번: DSLR
internal class Program
{
    static void Main(string[] args)
    {
        // 빠른 출력을 위해 StringBuilder 사용
        var sb = new StringBuilder();
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int A = input[0];
            int B = input[1];

            string[] commands = new string[10000]; // 각 숫자에 도달하기 위한 명령어 경로
            bool[] visited = new bool[10000];
            Queue<int> q = new Queue<int>();

            q.Enqueue(A);
            visited[A] = true;
            commands[A] = ""; // 시작점의 경로는 비어있음

            while (q.Count > 0)
            {
                int current = q.Dequeue();

                // 큐에서 꺼낸 값이 목표와 같다면, 탐색 종료. 이것이 최단 경로임.
                if (current == B)
                {
                    sb.AppendLine(commands[B]);
                    break;
                }

                // 1. D 명령어 (Double)
                int next = (current * 2) % 10000;
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    commands[next] = commands[current] + "D";
                }

                // 2. S 명령어 (Subtract)
                next = (current == 0) ? 9999 : current - 1;
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    commands[next] = commands[current] + "S";
                }

                // 3. L 명령어 (Left Rotate)
                next = (current % 1000) * 10 + (current / 1000);
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    commands[next] = commands[current] + "L";
                }

                // 4. R 명령어 (Right Rotate)
                next = (current % 10) * 1000 + (current / 10);
                if (!visited[next])
                {
                    q.Enqueue(next);
                    visited[next] = true;
                    commands[next] = commands[current] + "R";
                }
            }
        }
        Console.Write(sb.ToString());
    }
}