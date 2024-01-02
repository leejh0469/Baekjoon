public struct Meeting
{
    public Meeting(int startTime, int endTime)
    {
        this.startTime = startTime; this.endTime = endTime;
    }
    public int startTime;
    public int endTime;
}


internal class Program
{
    static public int Scheduling(List<Meeting> meetings)
    {
        List<Meeting> schedule = new List<Meeting>();

        int maxSchedule = 0;
        int prevEndTime = 0;
        foreach (Meeting meeting in meetings)
        {
            if (prevEndTime <= meeting.startTime)
            {
                schedule.Add(meeting);
                prevEndTime = meeting.endTime;
                maxSchedule++;
            }
        }

        return maxSchedule;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Meeting> meetings = new List<Meeting>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] s = input.Split(' ');
            int startTime = int.Parse(s[0]);
            int endTime = int.Parse(s[1]);
            meetings.Add(new Meeting(startTime, endTime));
        }

        meetings.Sort((x, y) =>
        {
            int ret = x.endTime.CompareTo(y.endTime);
            return ret != 0 ? ret : x.startTime.CompareTo(y.startTime);
        });

        int maxSchedule = Scheduling(meetings);

        Console.WriteLine(maxSchedule);
    }
}