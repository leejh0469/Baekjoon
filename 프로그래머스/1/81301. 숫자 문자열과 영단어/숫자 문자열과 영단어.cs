using System;

public class Solution {
    public int solution(string s) {
        int answer = 0;
        for(int i = 0; i < s.Length; i++){
            if(s[i] >= 97){
                answer *= 10;
                switch(s[i]){
                    case 'z':
                        answer += 0;
                        i += 3;
                        break;
                    case 'o':
                        answer += 1;
                        i += 2;
                        break;
                    case 't':
                        if(s[i+1] == 'w'){
                            answer += 2;
                            i += 2;
                        }
                        else{
                            answer += 3;
                            i += 4;
                        }
                        break;
                    case 'f':
                        if(s[i + 1] == 'o'){
                            answer += 4;
                            i +=3;
                        }
                        else{
                            answer += 5;
                            i += 3;
                        }
                        break;
                    case 's':
                        if(s[i+1] == 'i'){
                            answer += 6;
                            i += 2;
                        }
                        else{
                            answer += 7;
                            i += 4;
                        }
                        break;
                    case 'e':
                        answer += 8;
                        i += 4;
                        break;
                    case 'n':
                        answer += 9;
                        i+=3;
                        break;
                }
            }
            else{
                answer *= 10;
                answer += (int)(s[i] - '0');
            }
        }
        return answer;
    }
}