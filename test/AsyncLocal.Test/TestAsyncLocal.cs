using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AsyncLocal.Test
{
    public class TestAsyncLocal
    {
    
        public static TestAsyncLocal Instance = new TestAsyncLocal();
        private AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>((c) => {
            Console.WriteLine("PreviousValue:{1},CurrentValue:{0},ThreadContextChanged:{2}", c.CurrentValue, c.PreviousValue, c.ThreadContextChanged);
            Console.WriteLine("   CurrentCulture:{0},CurrentUICulture:{1},ManagedThreadId:{2},IsBackground:{3},IsThreadPoolThread:{4}",
                              Thread.CurrentThread.CurrentCulture,
                             Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
        });

        public string NormalString { get; set; }

        private TestAsyncLocal() { }


        public string AsyncLocalString => _asyncLocalString.Value;


        public void SetAsyncLocalString(string value)
        {
            ExecutionContext ec = ExecutionContext.Capture();
            _asyncLocalString.Value = value;
        }
    }
}
