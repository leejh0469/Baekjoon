using System;
using System.Text;

public class Solution {
    public string solution(int[] food) {
        string answer = "";
        StringBuilder sb = new StringBuilder();
        
        for(int i = 1; i < food.Length; i++){
            int n = food[i] / 2;
            
            for(int j = 0; j < n; j++){
                sb.Append((char)(i + '0'));
            }
        }
        
        sb.Append('0');
        
        answer = sb.ToString();
        
        sb.Clear();
        
        for(int i = answer.Length - 2; i >= 0; i--){
            sb.Append(answer[i]);
        }
        
        answer += sb.ToString();
        
        return answer;
    }
}