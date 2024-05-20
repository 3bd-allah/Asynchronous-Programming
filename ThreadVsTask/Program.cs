
namespace ThreadVsTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var t1 =  new Thread(()=> Display("3resha using Thread"));
            t1.Start();
            t1.Join();


            Task.Run(()=> Display("3resha using Task"));

        }

        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, pool: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}
