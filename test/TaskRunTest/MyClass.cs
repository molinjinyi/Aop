using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRunTest
{
    public class MyClass
    {
        public MyClass(int id)
        {
            Id = id;
        }
        public int Id { get; set; }


        public void Run()
        {
            Console.WriteLine("Id value is:{0}", Id);
            Console.WriteLine("Thread.CurrentThread.ManagedThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
            //Task.Run(() =>
            //{
            //    Console.WriteLine("Id value is:{0}", Id);
            //    Console.WriteLine("Thread.CurrentThread.ManagedThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

            //});
        }
        ~MyClass()
        {
            Console.WriteLine("MyClass Released ");
        }
    }
}
