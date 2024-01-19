using System;

public class Solution {
    public int solution(string[] babbling) {
        int answer = 0;
        string[] s = { "aya", "ye", "woo", "ma" };
        for (int j = 0; j < babbling.Length; j++)
        {
            int head = 0;
            int before = -1;

            bool ox = true;
            while (head < babbling[j].Length)
            {
                int i;
                bool isCorrect = false;
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i][0] == babbling[j][head] && i != before)
                    {
                        before = i;
                        isCorrect = true;
                        break;
                    }
                }

                if (isCorrect)
                {
                    for (int k = 0; k < s[i].Length; k++)
                    {
                        if(head >= babbling[j].Length){
                            ox = false;
                            break;
                        }
                        if (s[i][k] != babbling[j][head++])
                        {
                            head = babbling[j].Length;
                            ox = false;
                            break;
                        }
                    }
                }
                else
                {
                    ox = false;
                    break;
                }
            }
            if (ox)
            {
                answer++;
            }

        }
        return answer;
    }
}