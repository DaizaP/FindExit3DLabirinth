using Seminar2;

internal class Program
{
    private static void Main(string[] args)
    {
        Find find = new Find(5, 5, 5);
        find.PutRandomNumber(100);
        Console.WriteLine("Queue " + find.FindQueue(2, 2, 2));
    }
}