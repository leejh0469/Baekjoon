using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        int x = arr1.GetLength(0);
        int y = arr2.GetLength(1);
        int[,] answer = new int[x,y];
        
        for(int i = 0; i < x; i++){
            
            for(int j = 0; j < y; j++){
                int sum = 0;
                for(int k = 0; k < arr1.GetLength(1); k++){
                    sum += arr1[i, k] * arr2[k,j];
                }
                answer[i, j] = sum;
            }
        }
        
        return answer;
    }
}