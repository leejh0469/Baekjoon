using System;
using System.Collections.Generic;


class Solution
{
    public static List<int> list = new List<int>();
    public static int count = 0;

    public static void DFS(int n, int index, List<int> deci, int[] nums)
    {
        list.Add(nums[index]);

        if (n >= 2)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            if (deci.Contains(sum))
                count++;
        }
        else
        {
            for (int i = index + 1; i < nums.Length; i++)
            {
                DFS(n + 1, i, deci, nums);
            }
        }
        list.RemoveAt(list.Count - 1);
    }
    
    public int solution(int[] nums)
    {
        int answer = -1;

        Array.Sort(nums);
        int sum = 0;
        for (int i = nums.Length - 1; i >= nums.Length-3; i--)
        {
            sum += nums[i];
        }
        int[] numbers = new int[sum+1];
        List<int> deci = new List<int>();

        for (int i = 2; i < numbers.Length; i++)
        {
            if (numbers[i] == 0)
            {
                deci.Add(i);
                for (int j = 0; ; j++)
                {
                    if (i * j > sum)
                        break;
                    numbers[i * j] = 1;
                }
            }
        }

        for (int i = 0; i < nums.Length - 2; i++)
        {
            DFS(0, i, deci, nums);
        }
        answer = count;
        return answer;
    }
}