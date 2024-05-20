namespace ExceptionPorpagation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -- 1 --
            //try
            //{
            //    var th = new Thread(ThrowException);
            //    th.Start();
            //    th.Join();
            //}
            //catch 
            //{
            //    Console.WriteLine("Exception is thrown !!!");
            //}

            // -- 2 --
            //var th = new Thread(ThrowExceptionWithTryCatch);
            //th.Start();
            //th.Join();


            // -- 3 --
            try
            {
                Task.Run(() => ThrowException()).Wait();
            }
            catch
            {
                Console.WriteLine("Exception is thrown !!!");
            }


            Console.ReadKey();
        }

        static void ThrowException()
        {
            throw new NullReferenceException();
        }

        static void ThrowExceptionWithTryCatch()
        {
            try
            {
                ThrowException();
            }
            catch 
            {
                Console.WriteLine("Exception is thrown !!!");
            }
        }
    }
}
