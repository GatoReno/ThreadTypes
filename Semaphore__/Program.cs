using System;
using System.Threading;

namespace Semaphore__
{
    class MainClass
    {
        static Semaphore _sem = new Semaphore(1,1);
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello ManualResetEvent!!!");

            // new Thread(Write).Start();
            for (int i = 0; i < 6; i++)
            {
                new Thread(Write).Start();
            }

            Console.ReadLine();
        }


        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} w8ing ... ");
            _sem.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writting ... ");
            Thread.Sleep(5500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}  writing complete ... ");
            _sem.Release();
        }
    }
}
