using System;
using System.Collections.Generic;
public class Solution {
    public int solution(string s) {
        int answer = 0;
        Stack<char> stack = new Stack<char>();
        bool isCollect;
        for(int i = 0; i< s.Length; i++){
            isCollect = true;
            for(int j = 0 ; j <s.Length; j++){
                if(s[(j+i)%s.Length] == '[' || s[(j+i)%s.Length] == '(' || s[(j+i)%s.Length] == '{')
                    stack.Push(s[(j+i)%s.Length]);
                else{
                    char c = ' ';
                    if (stack.TryPop(out c))
                    {
                        if (c == '(')
                        {
                            if (s[(j + i) % s.Length] == ')')
                                continue;
                            else
                            {
                                isCollect = false;
                                j = s.Length;
                            }
                        }
                        else
                        {
                            if (s[(j + i) % s.Length] - 2 == c)
                                continue;
                            else
                            {
                                isCollect = false;
                                j = s.Length;
                            }
                        }
                    }
                    else
                    {
                        isCollect = false;
                        j = s.Length;
                    }
                }
            }
            if(isCollect && stack.Count == 0)
                answer++;
        }
        
        return answer;
    }
}