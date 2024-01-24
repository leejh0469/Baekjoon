public class Solution {
    public int[] solution(int n, int m) {
        int a;
        int tempN = n;
        int tempM = m;
        if(n < m){
            int temp = n;
            n = m;
            m = temp;
        }
        while(true){
            if(n % m == 0){
                break;
            }
            int temp= n;
            n = m;
            m = temp % m;
        }
        
        a = m;
        int b = tempN * tempM /a;
        int[] answer = new int[] {a, b};
        return answer;
    }
}