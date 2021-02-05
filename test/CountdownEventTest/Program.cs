using System;
using System.Threading;
using System.Threading.Tasks;

namespace CountdownEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            CountdownEvent cde = new CountdownEvent(3); // initial count = 10000
            int count = 0;
            // This is the logic for all queue consumers
            Action consumer = () =>
            {
                if (!cde.Signal())
                {
        
                    Console.WriteLine("ManagedThreadId:{0},count:{1}", Thread.CurrentThread.ManagedThreadId, count++);
                    // decrement CDE count once for each element consumed from queue
                    //cde.Signal();
                }
            };
            Task t1 = Task.Factory.StartNew(consumer);
            Task t2 = Task.Factory.StartNew(consumer);
            Task t3 = Task.Factory.StartNew(consumer);
            cde.Wait();
            autoResetEvent.WaitOne();
        }
    }
}
