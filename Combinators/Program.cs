namespace Combinators
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var has1000Subscribers = Task.Run(Has1000Subscribers);
            var has4000ViewHours = Task.Run(Has4000ViewHours);

            Console.WriteLine("Using WhenAny()");
            Console.WriteLine("----------------");
            var any = await Task.WhenAny(has1000Subscribers, has4000ViewHours);
            Console.WriteLine(any.Result);

            Console.WriteLine("Using WhenAll()");
            Console.WriteLine("----------------");
            var all = await Task.WhenAll(has1000Subscribers, has4000ViewHours);
            foreach(var t in all)
                Console.WriteLine($"{t}");

            Console.ReadKey(true);

        }

        public static async Task<string> Has1000Subscribers()
        {
            await Task.Delay(4000);
            return "Congrats !! you have reached 1000 subscribers";
        }

        public static async Task<string> Has4000ViewHours()
        {
            await Task.Delay(3000);
            return "Congrats !! you have reached 4000 view hours";
        }
    }
}
