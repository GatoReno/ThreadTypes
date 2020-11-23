using System;
using System.Threading;

namespace Lock
{
    class MainClass
    {
        private static object _locket = new object();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hellol Monitor!");
            for (int i = 0; i < 7; i++)
            {
                new Thread(DoWork).Start();
            }
            Console.ReadLine();
        }

        public static void DoWork()
        {
            //lock (_locket)
            Monitor.Enter(_locket);

            try
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting ...");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed ...");
            }
            catch (Exception ex)
            {
                // error logger
            }
            finally
            {
                Monitor.Exit(_locket);
            }
          
        }
    }
}
