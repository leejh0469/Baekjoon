using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        
        int mid = topping.Length / 2 - 1;
        
        Dictionary<int, int> left = new Dictionary<int, int>();
        Dictionary<int, int> right = new Dictionary<int, int>();
        
        for(int i = 0; i < topping.Length; i++){
            if(left.ContainsKey(topping[i])){
                left[topping[i]]++;
            }
            else{
                left.Add(topping[i], 1);
            }
        }
        
        for(int i = topping.Length - 1; i >= 0; i--){
            if(right.ContainsKey(topping[i])){
                right[topping[i]]++;
            }
            else{
                right.Add(topping[i], 1);
            }
            
            left[topping[i]]--;
            
            if(left[topping[i]] == 0)
                left.Remove(topping[i]);
            
            if(left.Count == right.Count)
                answer++;
        }
        
        return answer;
    }
}