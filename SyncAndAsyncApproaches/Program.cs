namespace SyncAndAsyncApproaches
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 7);
            CallSyncronous();

            ShowThreadInfo(Thread.CurrentThread, 10);
            CallAsyncronous();

            ShowThreadInfo(Thread.CurrentThread, 13);

            Console.ReadKey();


        }

        static void CallSyncronous()
        {
            Thread.Sleep(4000);
            ShowThreadInfo(Thread.CurrentThread, 23);
            Console.WriteLine("++++++++++++ Syncronous ++++++++++++ ");

        }

        static void CallAsyncronous()
        {
            ShowThreadInfo(Thread.CurrentThread, 30);
            Task.Delay(4000).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("++++++++++++ Asyncronous ++++++++++++ ");

            });
        }

        public static void ShowThreadInfo(Thread thread, int line)
        {

            Console.WriteLine($"line#:{line}, TID:{thread.ManagedThreadId}," +
                $" Pooled:{thread.IsThreadPoolThread}," +
                $" Background:{thread.IsBackground}");
        }

    }



}
