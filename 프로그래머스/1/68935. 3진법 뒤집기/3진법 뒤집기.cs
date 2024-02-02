using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        int index = 0;

        int a = 1;
        for (int i = 0; ; i++)
        {
            if (a * 3 > n)
                break;
            a *= 3;
        }

        while (n > 0)
        {
            if(n < a)
            {
                index++;
                a /= 3;
                continue;
            }

            int two = 1;
            for(int i = 0; i < index; i++)
            {
                two *= 3;
            }

            answer += two * (n / a);

            n %= a;
            a /= 3;
            index++;
        }
        return answer;
    }
}