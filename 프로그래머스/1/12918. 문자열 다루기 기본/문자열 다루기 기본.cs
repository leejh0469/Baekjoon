public class Solution {
    public bool solution(string s) {
        bool answer = true;
        int x;
        if(s.Length != 4 && s.Length != 6)
            answer = false;
        if(!int.TryParse(s, out x)){
            answer = false;
        }
        return answer;
    }
}