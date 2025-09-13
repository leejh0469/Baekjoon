using System.Text;

namespace ConsoleApp1
{
    public record Vector(double x, double y);

    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Vector> list = new List<Vector>();

            for(int i = 0; i < N; i++)
            {
                double[] input = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
                list.Add(new Vector(input[0], input[1]));
            }

            list.Add(new Vector(list[0].x, list[0].y));

            double sum1 = 0;
            double sum2 = 0;

            for(int i = 0; i < list.Count - 1; i++)
            {
                sum1 += list[i].x * list[i + 1].y;
                sum2 += list[i].y * list[i + 1].x;
            }

            double area = Math.Abs(sum1 - sum2) / 2;
            Console.WriteLine(area.ToString("F1"));
        }
    }
}
