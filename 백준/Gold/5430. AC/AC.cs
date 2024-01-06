using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            String input = Console.ReadLine();
            char[] orders = input.ToCharArray();

            int num = int.Parse(Console.ReadLine());
            string input2 = Console.ReadLine();
            input2 = input2.Substring(1, input2.Length - 2);
            string[] strArr = input2.Split(',');
            int[] ary = new int[num];
            for (int j = 0; j < num; j++)
            {
                ary[j] = int.Parse(strArr[j]);
            }

            bool isError = false;
            bool isFlip = false;
            int head = 0;
            int tail = ary.Length - 1;
            int length = ary.Length;
            for (int j = 0;j < orders.Length; j++)
            {
                switch (orders[j])
                {
                    case 'R':
                        isFlip = !isFlip;
                        break;
                    case 'D':
                        if(length == 0)
                        {
                            isError = true;
                            j = orders.Length;
                        }
                        else
                        {
                            if (isFlip)
                                tail -= 1;
                            else
                                head += 1;
                            length--;
                        }
                        break;
                    default:
                        break;
                }
            }


            StringBuilder stringBuilder = new StringBuilder();
            if(isError)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.Write("[");
                if (isFlip)
                {
                    for (int j = tail; j >= head; j--)
                    {
                        stringBuilder.Append(ary[j]);
                        if(j > head) stringBuilder.Append(',');
                    }
                }
                else
                {
                    for (int j = head; j <= tail; j++)
                    {
                        stringBuilder.Append(ary[j]);
                        if (j < tail) stringBuilder.Append(',');
                    }
                }
                Console.Write(stringBuilder);
                Console.WriteLine($"]");
            }
        }
    }
}