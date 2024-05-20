using System.Diagnostics;

namespace CancellationToken
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //await DoCheck01(cts);
            //await DoCheck02(cts);
            await DoCheck03(cts);



        }

        static async Task DoCheck01(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey(true);
                if(input.Key == ConsoleKey.Escape)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been canceled");
                }
            });


            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.Write("Cheking...");
                await Task.Delay(1000);
                Console.Write($"Completed on {DateTime.Now}");
                Console.WriteLine();
            }

            cancellationTokenSource.Dispose();


        }

        static async Task DoCheck02(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been canceled");
                }
            });


            try
            {
                while (true)
                {
                    Console.Write("Cheking...");
                    await Task.Delay(1000, cancellationTokenSource.Token);
                    Console.Write($"Completed on {DateTime.Now}");
                    Console.WriteLine();
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            cancellationTokenSource.Dispose();
        }

        static async Task DoCheck03(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been canceled");
                }
            });


            try
            {
                while (true)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Console.Write("Cheking...");
                    await Task.Delay(1000);
                    Console.Write($"Completed on {DateTime.Now}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            cancellationTokenSource.Dispose();


        }


    }
}
