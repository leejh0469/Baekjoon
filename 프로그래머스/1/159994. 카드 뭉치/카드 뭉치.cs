using System;

public class Solution {
    public string solution(string[] cards1, string[] cards2, string[] goal) {
        int head1 = 0;
        int head2 = 0;
        for(int i = 0; i< goal.Length; i++){
            if(head1 < cards1.Length && cards1[head1] == goal[i]){
                head1++;
            }
            else if(head2 < cards2.Length && cards2[head2] == goal[i]){
                head2++;
            }
            else
                break;
        }
        
        
        string answer = "";
        if(head1+ head2 == goal.Length)
            answer = "Yes";
        else
            answer = "No";
        return answer;
    }
}