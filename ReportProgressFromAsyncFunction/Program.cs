namespace ReportProgressFromAsyncFunction
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Action<int> progress = (n) =>
            {
                Console.Clear();
                Console.WriteLine($"{n}%");
            };

            await Copy(progress);

            Console.ReadKey();
        }

        public static Task Copy(Action<int> OnProgress)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Delay(50).Wait();
                    if (i % 10 == 0)
                    {
                        OnProgress(i);
                    }
                }
            });
        }
    }
}
