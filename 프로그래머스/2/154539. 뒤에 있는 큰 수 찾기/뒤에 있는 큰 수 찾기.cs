using System;

public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer = new int[numbers.Length];
        int[] index = new int[numbers.Length];

        answer[answer.Length - 1] = -1;

        int maxValue = -1;
        int maxValueIndex = 0;

        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            if (numbers[i] >= maxValue)
            {
                answer[i] = -1;
                maxValue = numbers[i];
                maxValueIndex = i;
                index[i] = i;
            }
            else
            {
                for (int j = i + 1; j <= maxValueIndex;)
                {
                    if (numbers[i] < numbers[j])
                    {
                        answer[i] = numbers[j];
                        index[i] = j;
                        break;
                    }
                    else
                    {
                        j = index[j];
                    }
                }
            }
        }
        return answer;
    }
}