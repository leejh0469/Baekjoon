using System;

public class Solution {
    public int[] solution(int n, long left, long right) {
        int[] arr = new int[right - left + 1];

    for (int i = 0; i < right - left + 1; i++)
    {
        int x = ((left+i) / n > (left + i) % n)? (int)((left + i) / n + 1) : (int)((left+i) % n + 1);

        arr[i] =  x;
    }
        int[] answer = arr;
        return answer;
    }
}