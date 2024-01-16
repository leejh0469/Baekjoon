using System;

public class Solution {
    public int solution(int left, int right) {
        int answer = 0;
        for(int i = left; i <= right; i++){
            for(int j = 1; j <= i; j++){
                if(j*j == i){
                    answer -= i*2;
                    break;
                }
            }
            answer += i;
        }
        
        return answer;
    }
}