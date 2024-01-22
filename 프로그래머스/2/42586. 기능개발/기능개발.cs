using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        int head = 0;
        List<int> list = new List<int>();
        while(head < progresses.Length){
            for(int i = 0; i < speeds.Length; i++){
                progresses[i] += speeds[i];
            }
            
            if(progresses[head] >= 100){
                int i;
                int count = 0;
                for(i = head; i < speeds.Length; i++){
                    if(progresses[i] < 100)
                        break;
                    count++;
                }
                head = i;
                list.Add(count);
            }
        }
        
        int[] answer = list.ToArray();
        return answer;
    }
}