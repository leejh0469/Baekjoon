using System;
public class Solution {
    public string solution(string s) {
        string lower = "";
        string upper = "";
        for(int i= 0; i < s.Length; i++){
            if(s[i] >= 'A' && s[i] <= 'Z')
                upper += s[i];
            else
                lower+= s[i];
        }
        char[] c1 = lower.ToCharArray();
        Array.Sort(c1);
        Array.Reverse(c1);
        string answer = "";
        answer += new String(c1);
        char[] c2 = upper.ToCharArray();
        Array.Sort(c2);
        Array.Reverse(c2);
        answer += new String(c2);
        return answer;
    }
}