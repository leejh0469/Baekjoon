using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
        int answer = 0;
        
        Queue<int> q = new Queue<int>();
        
        for(int i = 0; i < truck_weights.Length; i++){
            q.Enqueue(truck_weights[i]);
        }
        
        int totalWeight = 0;
        int s = 0;
        int e = 0;
        
        int[] moveDistance = new int[truck_weights.Length];
        
        while(q.Count > 0){
            if(totalWeight + q.Peek() <= weight){
                int truck = q.Dequeue();
                e++;
                totalWeight += truck;
            }
            
            for(int i = s; i < e; i++){
                moveDistance[i]++;
            }
            
            if(moveDistance[s] == bridge_length){
                totalWeight -= truck_weights[s];
                s++;
            }
                
            
            answer++;
        }
        
        return answer + (bridge_length - moveDistance[truck_weights.Length - 1]) + 1;
    }
}