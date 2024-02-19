using System;

public class Solution {
    public int solution(string s) {
        int answer = 0;
        char x = s[0];
        int countA = 1;
        int countB = 0;
        for(int i = 1; i < s.Length; i++){
            if(x != s[i]){
                countB++;
            }
            else
                countA++;
            
            if(countA == countB){
                answer++;
                if(i < s.Length - 1){
                    x = s[i+1];
                countA = 0;
                countB = 0;
                }
            }
        }
        if(countA != countB)
            answer++;
        
        return answer;
    }
}