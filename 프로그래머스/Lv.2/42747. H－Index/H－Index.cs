using System;

public class Solution {
    public int solution(int[] citations) {
        Array.Sort(citations);
        Array.Reverse(citations);
        int h = 0;
        for(int i = 0; i < citations.Length; i ++){
            if(citations[i] >= i + 1){
                if(h < i + 1)
                    h = i + 1;
            }
        }
        int answer = h;
        return answer;
    }
}