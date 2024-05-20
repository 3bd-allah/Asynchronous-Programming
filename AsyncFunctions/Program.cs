
namespace AsyncFunctions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //var task = Task.Run(() => ReadContent("https://www.coursera.org/learn/principles-of-ux-ui-design/home/week/4"));
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    Console.WriteLine(awaiter.GetResult());
            //});

            Console.WriteLine(await ReadContentAsync("https://www.coursera.org/learn/principles-of-ux-ui-design/home/week/4"));

            Console.ReadKey();

        }


        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();

            var content = client.GetStringAsync(url);

            return content;

        }
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var task =client.GetStringAsync(url);

            var content = await task;  
            DoSomeThing();
            return content;

        }

        private static void DoSomeThing()
        {
            Console.WriteLine("Loading ....");
        }
    }
}
