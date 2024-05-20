 namespace TaskReturnsValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thread 
            Thread th = new Thread(()=> GetDate()); // date 1 
            th.Start();
            th.Join();
            Console.WriteLine(th);                  // thread namespace  

            // task
            Task.Run(GetDate);                      //date 2


            // Task<>
            Task<DateTime> task = Task.Run(GetDateInfo);
            Console.WriteLine(task.Result);         // date 3 
            Console.WriteLine(task);                // task namespace

            Console.ReadKey();
        }

        static DateTime GetDateInfo() => DateTime.Now;

        static void GetDate()
        {
            Console.WriteLine(DateTime.Now);
        }

    }
}
