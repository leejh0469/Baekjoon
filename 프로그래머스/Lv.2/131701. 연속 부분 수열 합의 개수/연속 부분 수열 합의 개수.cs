using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    
    public int solution(int[] elements) {
        
        int[] arr = elements.Concat(elements).ToArray();
        
        HashSet<int> hs = new HashSet<int>();
        
        for(int i = 0; i < elements.Length; i++){
            int sum = 0;
            for(int j = 0; j < elements.Length; j++){
                sum += arr[i+j];
                hs.Add(sum);
            }
        }
        
        int answer = hs.Count;
        return answer;
    }
}