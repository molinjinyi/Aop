using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace TimerTest
{
    class Program
    {
        private readonly static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static int _count = 0;
        static void Main(string[] args)
        {
            var timer = new Timer((a)=> {
                _count++;
                Console.WriteLine(_count);
                if (_count > 10) autoResetEvent.Set();
            },null, Timeout.Infinite, Timeout.Infinite);
            Console.WriteLine("Hello World!");
            timer.Change(100, 200);
           Console.WriteLine(autoResetEvent.WaitOne(2000));
        }
    }
}
