using System;
using System.Linq;

namespace PCroom
{
    class PCroom
    {
        static void Main(string[] args)
        {
            int a;
            int sum = 0;
            for(int i = 0; i < 4; i++){
                a = int.Parse(Console.ReadLine());
                sum += a;
            }
            
            Console.WriteLine(sum / 60);
            Console.WriteLine(sum % 60);
        }
    }
}