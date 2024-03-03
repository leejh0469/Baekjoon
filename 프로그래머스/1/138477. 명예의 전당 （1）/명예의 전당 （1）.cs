using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int k, int[] score) {
        int[] answer = new int[] {};
        
        List<int> a = new List<int>();
        List<int> list = new List<int>();
        
        for(int i = 0; i < score.Length; i++){
            list.Add(score[i]);
            list.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));
            if(i < k){
                a.Add(list[i]);
            }
            else{
                a.Add(list[k - 1]);
            }
        }
        answer = a.ToArray();
        return answer;
    }
}