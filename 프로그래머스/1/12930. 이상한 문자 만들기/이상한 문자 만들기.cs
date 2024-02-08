using System.Text;
using System;
public class Solution {
    public string solution(string s) {
        string answer = "";
        int index = 0;
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++){
            if (s[i] != ' ')
            {
                if (index % 2 == 0)
                {
                    sb.Append(Char.ToUpper(s[i]));
                    index++;
                }
                else
                {
                    sb.Append(Char.ToLower(s[i]));
                    index++;
                }
            }
            else
            {
                index = 0;
                sb.Append(' ');
            }
        }
        answer = sb.ToString();
        return answer;
    }
}