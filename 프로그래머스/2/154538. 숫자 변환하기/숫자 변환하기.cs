using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int x, int y, int n) {
        int answer = 0;
        
        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[1000001];
        int[] distance = new int[1000001];
        distance[x] = 0;
        if(x != y)
            distance[y] = -1;
        visited[x] = true;
        q.Enqueue(x);
        
        while(q.Count > 0){
            int a = q.Dequeue();
            
            if(a == y)
                break;
            
            if(a + n <= y && !visited[a + n]){
                q.Enqueue(a + n);
                visited[a + n] = true;
                distance[a + n] = distance[a] + 1;
            }
            
            if(a * 2 <= y && !visited[a * 2]){
                q.Enqueue(a * 2);
                visited[a * 2] = true;
                distance[a * 2] = distance[a] + 1;
            }
            
            if(a * 3 <= y && !visited[a * 3]){
                q.Enqueue(a * 3);
                visited[a * 3] = true;
                distance[a * 3] = distance[a] + 1;
            }
        }
        
        answer = distance[y];
        
        return answer;
    }
}