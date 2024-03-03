using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        int[] answer = new int[] {};
        List<int> list = new List<int>();
        for(int i = 0; i < commands.GetLength(0); i++){
            List<int> l = new List<int>();
            for(int j = commands[i, 0] - 1; j < commands[i, 1]; j++){
                l.Add(array[j]);
            }
            l.Sort();
            list.Add(l[commands[i,2] - 1]);
        }
        answer = list.ToArray();
        return answer;
    }
}