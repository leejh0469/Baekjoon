using System;

public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
        int answer = 0;
        
        for(int i = 0; i <= discount.Length - 10; i++){
            int[] arr = (int[])number.Clone();
            for(int j = i; j < i + 10; j++){
                for(int k = 0; k < want.Length; k++){
                    if(discount[j] == want[k]){
                        arr[k]--;
                        break;
                    }
                }
                bool isEnd = true;
                for(int k = 0; k < want.Length; k++){
                    if(arr[k] != 0){
                        isEnd = false;
                        break;
                    }
                }
                if(isEnd){
                    answer++;
                    break;
                }
            }
        }
        
        return answer;
    }
}