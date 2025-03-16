using System;
using System.Text;

public class Solution {
    public string solution(int[] numbers) {
        string answer = "";
        
        for(int i = 0; i < numbers.Length; i++){
            if(numbers[i] != 0)
                break;
            
            if(i == numbers.Length - 1)
                return "0";
        }
        
        string[] sArray = new string[numbers.Length];
        
        for(int i = 0; i < numbers.Length; i++)
        {
            sArray[i] = numbers[i].ToString();
        }

        Array.Sort(sArray);
        Array.Reverse(sArray);

        Array.Sort(sArray, (a, b) =>
        {
            if (int.Parse(a + b) > int.Parse(b + a))
                return -1;
            else
                return 1;
        });

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < sArray.Length; i++)
        {
            sb.Append(sArray[i]);
        }
        
        return sb.ToString();
    }
}