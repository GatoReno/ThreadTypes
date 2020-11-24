using System;
using System.Threading;

namespace _autoresetEventTest
{
    class MainClass
    {
        static AutoResetEvent _autoreset = new AutoResetEvent(true);
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
            _autoreset.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} w8ing ... ");
             Thread.Sleep(5500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}  writing complete ... ");
            _autoreset.Set();
        }


        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting ... ");
             Thread.Sleep(2500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} read complete ... ");
        }
    }


}
