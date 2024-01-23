using System;

public class Solution {
    public int solution(int[] priorities, int location) {
        int answer = 0;
        int head = 0;
        bool[] isEnd = new bool[priorities.Length];
        while(true){
            int max = 0;
            int maxIdx = -1;
            for(int i = head; i< priorities.Length + head; i++){
                int index = i % priorities.Length;
                if(max < priorities[index] && !isEnd[index]){
                    max = priorities[index];
                    maxIdx = index;
                }
            }
            answer++;
            isEnd[maxIdx] = true;
            head = (maxIdx + 1) % priorities.Length;
            if(maxIdx == location)
                break;
        }
        return answer;
    }
}