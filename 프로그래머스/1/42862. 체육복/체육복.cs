using System;

public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
        int answer = n - lost.Length;
        
        Array.Sort(lost);
        Array.Sort(reserve);
        
        for(int i = 0; i < reserve.Length; i++){
            int x = reserve[i];
            for(int j = 0; j < lost.Length; j++){
                if(reserve[i] == lost[j]){
                    answer++;
                    lost[j] = -1;
                    reserve[i] = -1;
                    break;
                }
            }
        }
        
        for(int i = 0; i< reserve.Length; i++){
            int x = reserve[i];
            
            if(reserve[i] == -1)
                continue;
            
            for(int j = 0; j < lost.Length; j++){
                if(lost[j] == x + 1 || lost[j] == x - 1){
                    lost[j] = -2;
                    answer++;
                    break;
                }
            }
        }
        
        return answer;
    }
}