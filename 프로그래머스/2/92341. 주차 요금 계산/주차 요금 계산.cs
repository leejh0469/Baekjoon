using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int CalcFee(int[] fees, int time){
        int fee = fees[1];

        if (time > fees[0])
        {
            fee += (int)(fees[3] * MathF.Ceiling((time - fees[0]) / (float)fees[2]));
        }

        return fee;
    }
    
    public int[] solution(int[] fees, string[] records) {
        
        Dictionary<string, int> carInRecord = new Dictionary<string, int>();
        Dictionary<string, int> totalParkingTime = new Dictionary<string, int>();

        for (int i = 0; i < records.Length; i++)
        {
            string[] record = records[i].Split(' ');
            string[] time = record[0].Split(":");
            int parkingTime = int.Parse(time[0]) * 60 + int.Parse(time[1]);

            string carNum = record[1];

            bool isIn = false;
            if (record[2] == "IN")
                isIn = true;

            if (isIn)
            {
                if (!totalParkingTime.ContainsKey(carNum))
                    totalParkingTime.Add(carNum, 0);

                carInRecord.Add(carNum, parkingTime);
            }
            else
            {
                int carInTime = carInRecord[carNum];

                totalParkingTime[carNum] += parkingTime - carInTime;

                carInRecord.Remove(carNum);
            }
        }

        foreach (KeyValuePair<string, int> item in carInRecord)
        {
            totalParkingTime[item.Key] += 1439 - item.Value;
        }



        List<string> list = totalParkingTime.Keys.ToList();

        list.Sort();

        int[] answer = new int[list.Count];

        for (int i = 0; i < list.Count; i++)
        {
            answer[i] = CalcFee(fees, totalParkingTime[list[i]]);
        }
        
        return answer;
    }
}