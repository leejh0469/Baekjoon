using System;

public class Solution {
    public int solution(int n, int m, int[] section) {
        int answer = 0;
        int last = 0;
        bool ing = false;
        for(int i = 0; i < section.Length; i++){
            if(last <= section[i]){
                answer++;
                last = section[i] + m;
                ing = true;
            }
        }
        
        return answer;
    }
}