using System.Text;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        // 모듈러 값을 상수로 정의
        static long MOD = 1000000007;

        static void Main(string[] args)
        {
            // 빠른 입력을 위해 StreamReader 사용
            var sr = new StreamReader(Console.OpenStandardInput());
            int M = int.Parse(sr.ReadLine());

            long totalSum = 0;

            for (int i = 0; i < M; i++)
            {
                string[] input = sr.ReadLine().Split();
                long N = long.Parse(input[0]);
                long S = long.Parse(input[1]);

                // 페르마의 소정리에 따라 역원은 N^(MOD-2)
                long inverseN = Power(N, MOD - 2);

                long term = (S * inverseN) % MOD;
                totalSum = (totalSum + term) % MOD;
            }

            Console.WriteLine(totalSum);
        }

        // long 타입을 사용하고, 효율적으로 수정한 Power 함수
        static long Power(long b, long exp)
        {
            // 기저 사례: 지수가 0이면 1 반환
            if (exp == 0) return 1;
            if (exp == 1) return b % MOD;

            // ✅ 재귀 호출을 한 번만 하여 결과를 저장
            long half = Power(b, exp / 2);

            // ✅ long 타입으로 계산하고, 곱할 때마다 모듈러 연산
            long halfSquared = (half * half) % MOD;

            // 지수가 홀수이면 밑을 한 번 더 곱해줌
            if (exp % 2 == 1)
            {
                return (halfSquared * b) % MOD;
            }
            // 지수가 짝수이면 그대로 반환
            else
            {
                return halfSquared;
            }
        }
    }
}