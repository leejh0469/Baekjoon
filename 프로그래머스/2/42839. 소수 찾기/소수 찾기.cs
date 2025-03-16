using System;

public class Solution {
    public static bool[] prime;
    public static int answer = 0;
    
    public int solution(string numbers) {
        char[] chars = numbers.ToCharArray();

        Array.Sort(chars);

        numbers = new string(chars);

        prime = new bool[10000000];
        prime[0] = true;
        prime[1] = true;

        for (int i = 2; i < 5000000; i++)
        {
            if (!prime[i])
            {
                int cnt = 2;
                int n = i * cnt;
                while (n < 10000000)
                {
                    prime[n] = true;
                    cnt++;
                    n = i * cnt;
                }
            }
        }

        DFS(0, numbers.Length, numbers, "");
        
        return answer;
    }
    
    public static void DFS(int depth, int length, string numbers, string piece)
    {
        if (depth == length)
        {
            return;
        }

        char previous = ' ';

        for (int i = 0; i < numbers.Length; i++)
        {
            if (previous != numbers[i])
            {
                if (depth == 0 && numbers[i] == '0')
                    continue;

                string s = piece + numbers[i];
                previous = numbers[i];

                string remain = numbers.Remove(i, 1);

                if (!prime[int.Parse(s)])
                {
                    answer++;
                }

                DFS(depth + 1, length, remain, s);
            }
        }
    } 
}