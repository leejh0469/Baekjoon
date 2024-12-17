namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string third = Console.ReadLine();

            if (third != "FizzBuzz" && third != "Fizz" && third != "Buzz")
            {
                print(int.Parse(third) + 1);
            }
            else if(second != "FizzBuzz" && second != "Fizz" && second != "Buzz")
            {
                print(int.Parse(second) + 2);
            }
            else if(first != "FizzBuzz" && first != "Fizz" && first != "Buzz")
            {
                print(int.Parse(first) + 3);
            }
        }

        static void print(int n)
        {
            if(n % 3 == 0 && n % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(n % 3 == 0 && n % 5 != 0)
            {
                Console.WriteLine("Fizz");
            }
            else if(n % 3 != 0 && n%5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(n);
            }
        }
    }
}
