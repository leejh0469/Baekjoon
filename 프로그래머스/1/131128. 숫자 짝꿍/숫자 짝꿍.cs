using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string solution(string X, string Y) {
        string answer = "";
        Dictionary<char, int> dictX = new Dictionary<char, int>();
        Dictionary<char, int> dictY = new Dictionary<char, int>();
        
        for(int i = 0; i < X.Length; i++){
            for(int j = 0; j < 10; j++){
                if(X[i] - '0' == j){
                    if(dictX.ContainsKey(X[i]))
                        dictX[X[i]]++;
                    else
                        dictX.Add(X[i], 1);
                }
            }
        }
        
        for(int i = 0; i < Y.Length; i++){
            for(int j = 0; j < 10; j++){
                if(Y[i] - '0' == j){
                    if(dictY.ContainsKey(Y[i]))
                        dictY[Y[i]]++;
                    else
                        dictY.Add(Y[i], 1);
                }
            }
        }
        StringBuilder sb = new StringBuilder();
        
        for (int i = 9; i >= 0; i--)
        {
            int count = 0;
            char c = (char)(i + '0');
            if (dictX.ContainsKey(c) && dictY.ContainsKey(c))
            {
                if (dictX[c] <= dictY[c])
                    count = dictX[c];
                else
                    count = dictY[c];

                for (int j = 0; j < count; j++)
                {
                    sb.Append(c);
                }
            }
        }
        answer = sb.ToString();
        if(answer.Length == 0){
            answer = "-1";
        }else if(answer[0] == '0')
        {
            answer = "0";
        }
        
        return answer;
    }
}