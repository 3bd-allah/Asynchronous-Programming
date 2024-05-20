namespace TaskDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DelayUsingTask(3000);

            Console.ReadKey();
        }

        static async void DelayUsingTask (int ms)
        {
            //Task.Delay (ms).GetAwaiter().OnCompleted(()=>
            //{
            //    Console.WriteLine($"Completed after Task.Delay({ms})");
            //});

            //or

            await Task.Delay(ms);
            Console.WriteLine($"Completed after Task.Delay({ms})");
        }

        static void SleepUsingThread (int ms)
        {
            Thread.Sleep (ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }
    }
}
