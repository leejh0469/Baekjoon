using System;

public class Solution {
    public int solution(int k, int m, int[] score) {
        int answer = 0;
        Array.Sort(score);
        Array.Reverse(score);
        
        for(int i =0; i < score.Length; i += m){
            if(i + m > score.Length)
                break;
            int min = k+1;
            for(int j = i; j < i + m; j ++){
                if(min > score[j])
                    min = score[j];
            }
            answer += min * m;
        }
        return answer;
    }
}