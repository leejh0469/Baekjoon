using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int[] solution(int[] answers) {
        int[] count = new int[3];
        int[] answer2 = {2, 1, 2, 3, 2, 4, 2, 5};
        int[] answer3 = {3 ,3, 1, 1, 2, 2, 4, 4, 5, 5};
        
        for(int i = 0; i < answers.Length; i++){
            if(answers[i] == i % 5 +1 )
                count[0]++;
            if(answers[i] == answer2[i%8])
                count[1]++;
            if(answers[i] == answer3[i%10])
                count[2]++;
        }
        
        int max = count.Max();
        List<int> list = new List<int>();
        for(int i = 0; i < 3; i++){
            if(max == count[i])
                list.Add(i+1);
        }
        
        int[] answer = list.ToArray();
        return answer;
    }
}