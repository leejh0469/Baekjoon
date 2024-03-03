public class Solution {
    public string solution(int a, int b) {
        string answer = "";
        
        string[] day = new string[7] {"THU","FRI","SAT", "SUN","MON","TUE","WED"};
        int[] month = new int[12]{31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        
        int x = 0;
        
        for(int i = 0; i < a - 1; i++){
            x += month[i];
        }
        
        x += b;
        
        return day[x % 7];
    }
}