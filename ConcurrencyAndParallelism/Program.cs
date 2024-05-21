namespace ConcurrencyAndParallelism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var things = new List<DailyDuty> {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

            Console.WriteLine("Using parallel processing ");
            ProcessInParallel(things);

            Console.WriteLine("Using Concurrent processing ");
            ProcessInConcurrent(things);


            Console.ReadKey(true);
        }

        static void ProcessInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process());
        }

        static void ProcessInConcurrent (IEnumerable<DailyDuty> things)
        {
            foreach(var thing in things)
                thing.Process();
        }


    }

    class DailyDuty
    {
        public string? Title { get;private set; }
        public bool Processed { get; private set; }
        public DailyDuty(string title)
        {
            this.Title = title;
        }

        public void Process()
        {
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}, " +
                $"Processor ID: {Thread.GetCurrentProcessorId()}");
            Task.Delay(1000).Wait();
            this.Processed = true;  

        }
    }

}
