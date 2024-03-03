using System.Collections.Generic;
using System.Linq;
public class Solution {
    public string[] solution(string[] strings, int n) {
        string[] answer = new string[] { };
        List<string> list = strings.ToList();
        list.Sort((x, y) => {
            int ret = x[n].CompareTo(y[n]);
            return ret != 0 ? ret : x.CompareTo(y); 
        });
        answer = list.ToArray();
        return answer;
    }
}