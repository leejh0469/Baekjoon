internal class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        int[] arr = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            arr[s[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            Console.Write(arr[i]+ " ");
        }
    }
}