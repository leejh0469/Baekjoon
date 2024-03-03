using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string s) {
        List<int> answer = new List<int>();
        int[] alpha = new int[26];
        for(int i = 0; i < alpha.Length; i++){
            alpha[i] = -1;
        }
        
        for(int i = 0; i < s.Length; i++){
            int alphaIndex = (int)(s[i] - 'a');
            if(alpha[alphaIndex] == -1){
                answer.Add(-1);
            }
            else{
                answer.Add(i - alpha[alphaIndex]);
            }
            alpha[alphaIndex] = i;
        }
        
        return answer.ToArray();
    }
}