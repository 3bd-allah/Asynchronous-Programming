namespace CARunLongTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var task = Task.Factory.StartNew(() => RunLongTask() , TaskCreationOptions.LongRunning);
            task.Wait();
            //Console.WriteLine("hello");
        }

        static void RunLongTask()
        {
            //Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
        
    }
}
