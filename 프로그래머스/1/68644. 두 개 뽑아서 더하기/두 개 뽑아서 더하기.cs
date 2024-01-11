using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int[] solution(int[] numbers) {
        Array.Sort(numbers);
        SortedSet<int> st = new SortedSet<int>();
        
        for (int i = 0; i < numbers.Length; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
    {
        st.Add(numbers[i] + numbers[j]);
    }
}
        
        int[] answer = st.ToArray();
        return answer;
    }
}