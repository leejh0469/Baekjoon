using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int k, int[] tangerine) {
        int answer = 0;
        var dict = new Dictionary<int, int>();
        
        for(int i = 0; i < tangerine.Length; i++){
            if(dict.ContainsKey(tangerine[i]))
                dict[tangerine[i]]++;
            else
                dict.Add(tangerine[i], 1);
        }
        
        var list = dict.OrderByDescending(x => x.Value).ToList();
        
        for(int i = 0; i < list.Count; i++){
            k -= list[i].Value;
            answer++;
            
            if(k <= 0)
                break;
        }
        return answer;
    }
}