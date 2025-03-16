using System;
using System.Text;

public class Solution {
    public long[] solution(long[] numbers) {
        long[] answer = new long[numbers.Length];
        
        for(int i = 0; i < numbers.Length; i++){
            string s = ToBinary(numbers[i]);
            
            int lastIndex = -1;
            
            long result = 0;
            int size = s.Length;
            
            for(int j = 0; j < size; j++){
                if(s[j] == '0'){
                    lastIndex = j;
                }
            }
            
            if(lastIndex == -1){
                result = ToLong("10" + s.Substring(1));
            }
            else if(lastIndex == size - 1){
                result = ToLong(s.Substring(0, size - 1) + "1");
            }
            else{
                StringBuilder sb = new StringBuilder(s);

                sb[lastIndex] = '1';
                sb[lastIndex + 1] = '0';

                result = ToLong(sb.ToString());
            }
            
            answer[i] = result;
        }
        
        return answer;
    }
    
    public string ToBinary(long num){
        StringBuilder sb = new StringBuilder();

        while (num >= 2)
        {
            sb.Append(num % 2);
            num /= 2;
        }

        sb.Append(num);

        StringBuilder reverse = new StringBuilder();

        for(int i = sb.Length - 1; i >= 0; i--)
        {
            reverse.Append(sb[i]);
        }

        return reverse.ToString();
    }
    
    public long ToLong(string binary){
        long sum = 0;
        int cnt = 0;
        
        for(int i = binary.Length - 1; i >= 0; i--){
            if(binary[i] == '1'){
                sum += (long)MathF.Pow(2, cnt);
            }
            
            cnt++;
        }
        
        return sum;
    }
}