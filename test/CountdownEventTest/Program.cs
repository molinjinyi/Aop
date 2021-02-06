using System;
using System.Threading;
using System.Threading.Tasks;

namespace CountdownEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Guid.NewGuid().ToString("N")); //"N", "D", "B", "P", or "X"
            Console.WriteLine(Guid.NewGuid().ToString("D"));
            Console.WriteLine(Guid.NewGuid().ToString("B"));
            Console.WriteLine(Guid.NewGuid().ToString("P"));
            Console.WriteLine(Guid.NewGuid().ToString("X"));
            Console.WriteLine(Guid.NewGuid().ToString(""));
            Console.WriteLine(Guid.NewGuid().ToString());
            var student = new Student {
                Id = 1,
                Name = "jini"
            };
            Console.WriteLine(student.Name);
            Change(student);
            Console.WriteLine(student.Name);
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
            //autoResetEvent.WaitOne();
        }

        public static void Change(Student student)
        {
            student.Name = "wj";
            Console.WriteLine(student.Name);
            student = new Student {
                Name = "www",
                 Id=2
            }; 
            Console.WriteLine(student.Name);
        }
    }
    public class Student {
     public int Id { get; set; }

        public string Name { get; set; }
    }
}
