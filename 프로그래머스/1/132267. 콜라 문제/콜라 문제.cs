using System;

public class Solution {
    public int solution(int a, int b, int n) {
        int answer = 0;
        
        while(n >= a){
            int x = (n / a) * b;
            n = n % a + x;
            answer += x;
        }
        
        return answer;
    }
}