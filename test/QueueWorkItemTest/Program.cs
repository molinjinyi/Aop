using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QueueWorkItemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("start...");
            //ThreadPool.QueueUserWorkItem(Work, 1);
            //Thread.Sleep(20000);
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                var task = Task.Run(() =>
                {
                    var item = i;// new Random().Next(1100);
                    Console.WriteLine("i={1},Thread.CurrentThread.ManagedThreadId:{0},Thread.CurrentThread.IsBackground:{2}, Thread.CurrentThread.IsThreadPoolThread:{3}, Thread.CurrentThread.Name:{4}", Thread.CurrentThread.ManagedThreadId, item, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.Name);
                });
                tasks[i] = task;
            }

            for (int i = 0; i < 10; i++)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var item = i;// new Random().Next(1100);
                    Console.WriteLine("i={1},Thread.CurrentThread.ManagedThreadId:{0},Thread.CurrentThread.IsBackground:{2}, Thread.CurrentThread.IsThreadPoolThread:{3}, Thread.CurrentThread.Name:{4}", Thread.CurrentThread.ManagedThreadId, item, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.Name);
                });
                tasks[i] = task;
            }
            //Task.WaitAll(tasks);
            var whenAllTask= Task.WhenAll(tasks);
            whenAllTask.Wait();
           
          

        }

        private static void Work(object state)
        {
            Console.WriteLine(state);
            Thread.Sleep(10000);
            Console.WriteLine("end...");
        }
    }
}
