using System;
using System.Threading;

namespace QueueWorkItemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start...");
            ThreadPool.QueueUserWorkItem(Work,1);
            Thread.Sleep(20000);
        }

        private static void Work(object state)
        {
            Console.WriteLine(state);
            Thread.Sleep(10000);
            Console.WriteLine("end...");
        }
    }
}
