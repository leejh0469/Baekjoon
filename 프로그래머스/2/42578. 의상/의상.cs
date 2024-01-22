using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
        
        int answer = 1;
        Dictionary<string, int> d = new Dictionary<string, int>();
        for(int i = 0; i < clothes.GetLength(0); i++){
            if(d.ContainsKey(clothes[i, 1]))
                d[clothes[i, 1]]++;
            else
                d.Add(clothes[i,1], 1);
        }
        foreach(var i in d.Values){
            answer *= i + 1;
        }
        
        return answer - 1;
    }
}