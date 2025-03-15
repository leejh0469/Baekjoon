using System;

public class Solution {
    
    public static char[] alpha = { 'A', 'E', 'I', 'O', 'U'};
    public static int a = 0;
    public int solution(string word) {
        int answer = 0;
        
        DFS(0, word, "");
        
        answer = a;
        
        return answer;
    }
    
    public bool DFS(int depth, string word, string sb){
        if (depth == 5)
        {
            return false;
        }

        string temp;

        for (int i = 0; i < 5; i++)
        {
            temp = sb;
            temp += alpha[i];
            a++;

            if (temp == word)
                return true;

            if (DFS(depth + 1, word, temp))
                return true;
        }

        return false;
    }
}