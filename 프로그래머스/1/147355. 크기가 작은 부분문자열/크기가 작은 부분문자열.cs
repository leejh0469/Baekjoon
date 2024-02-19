using System;

public class Solution {
    public int solution(string t, string p) {
        int answer = 0;
        
        for(int i = 0; i < t.Length - p.Length + 1; i++){
            for(int j = 0; j < p.Length; j++){
                if(t[i+j] < p[j]){
                    answer++;
                    break;
                }
                
                if(t[i+j] > p[j]){
                    break;
                }
                
                if(j == p.Length - 1)
                    answer++;
            }
        }
        
        return answer;
    }
}