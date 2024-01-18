using System;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
        int countZero = 0;
        
        for(int i = 0; i < lottos.Length; i++){
            if(lottos[i] == 0){
                countZero++;
            }
        }
        
        Array.Sort(lottos);
        int countMatch = 0;
        for(int i = countZero; i < lottos.Length; i++){
            for(int j = 0; j < win_nums.Length; j++){
                if(lottos[i] == win_nums[j]){
                    countMatch++;
                    break;
                }
            }
        }
        
        int max = 7 - (countZero + countMatch);
        if(max == 7)
            max = 6;
        
        int min = 7 - (countMatch);
        if(min == 7)
            min = 6;
        
        int[] answer = new int[] {max, min};
        return answer;
    }
}