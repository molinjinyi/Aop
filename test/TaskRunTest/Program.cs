using System;
using System.Threading;

namespace TaskRunTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Thread.CurrentThread.ManagedThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
            //MyClass myClass = new MyClass(10);

            //myClass.Run();
            //GC.Collect();
            ////GC.SuppressFinalize(myClass);
            //GC.Collect();
            var guid = Guid.NewGuid().ToString("N");
            Console.WriteLine("ConsoleMonitor instance....{0}", guid);
            ConsoleMonitor monitor = new ConsoleMonitor();
            monitor.Write();
            monitor.Dispose();

        }
    }
}
