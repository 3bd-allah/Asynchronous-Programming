using System.Threading.Channels;

namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Task<int> task = Task.Run(() => CountPrimeNumbersInRange(2, 3000000));
            //Console.WriteLine(task.Result);   // Result prop is bad because it blocks the Thread 

            //Console.WriteLine("using awaiter, OnComplete");
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    Console.WriteLine(awaiter.GetResult());
            //});


            task.ContinueWith(x => Console.WriteLine(x.Result));

            Console.WriteLine("3resha");


            Console.ReadKey();



        }

        static int CountPrimeNumbersInRange(int lowerBound , int upperBound)
        {
            var count = 0;
            for (var i = lowerBound; i < upperBound; i++)
            {
                var j = lowerBound;
                var isPrime = true;
                while (j <= (int)Math.Sqrt(i))
                {
                    if(i % j ==0)
                    {
                        isPrime = false;
                        break;
                    }
                    ++j; 
                }
                if (isPrime) 
                    ++count;

            }
                return count;
        }

    }
}
