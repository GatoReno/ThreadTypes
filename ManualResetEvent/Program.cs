using System;
using System.Threading;

namespace ManualResetEventTest
{

    class MainClass
    {
       static ManualResetEvent _mannual = new ManualResetEvent(false);
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello ManualResetEvent!!!");

            new Thread(Write).Start();
            for (int i = 0; i < 6; i++)
            {
                new Thread(Read).Start();
            }

            Console.ReadLine();
        }


        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing ... ");
            _mannual.Reset();
            Thread.Sleep(5500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}  writing complete ... ");
            _mannual.Set();
        }


        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting ... ");
            _mannual.WaitOne();
            Thread.Sleep(2500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} read complete ... ");
        }
    }
}
