using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLocal.Test
{
    class Program
    {
        static AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>();

        static ThreadLocal<string> _threadLocalString = new ThreadLocal<string>();

        static async Task AsyncMethodA()
        {
            // Start multiple async method calls, with different AsyncLocal values.
            // We also set ThreadLocal values, to demonstrate how the two mechanisms differ.
            _asyncLocalString.Value = "Value 1";
            _threadLocalString.Value = "Value 1";
            var t1 = AsyncMethodB("Value 1");

            _asyncLocalString.Value = "Value 2";
            _threadLocalString.Value = "Value 2";
            var t2 = AsyncMethodB("Value 2");
            // Await both calls
            await t1;
            await t2;
        }

        static async Task AsyncMethodB(string expectedValue)
        {
            Console.WriteLine("Entering AsyncMethodB.");
            Console.WriteLine("   Expected '{0}', AsyncLocal value is '{1}', ThreadLocal value is '{2}',CurrentCulture:{3},CurrentUICulture:{4},ManagedThreadId:{5},IsBackground:{6},IsThreadPoolThread:{7}",
                              expectedValue, _asyncLocalString.Value, _threadLocalString.Value,Thread.CurrentThread.CurrentCulture,
                              Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
            await Task.Delay(100);
            Console.WriteLine("Exiting AsyncMethodB.");
            Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}',CurrentCulture:{3},CurrentUICulture:{4},ManagedThreadId:{5},IsBackground:{6},IsThreadPoolThread:{7}",
                              expectedValue, _asyncLocalString.Value, _threadLocalString.Value, Thread.CurrentThread.CurrentCulture,
                              Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
        }

        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            //await AsyncMethodA();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" -----  CurrentCulture:{0},CurrentUICulture:{1},ManagedThreadId:{2},IsBackground:{3},IsThreadPoolThread:{4}",
                               Thread.CurrentThread.CurrentCulture,
                              Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
            TestAsyncLocal.Instance.SetAsyncLocalString("初始化");
            ExecutionContext ec = ExecutionContext.Capture();
            for (int i = 0; i < 1; i++)
            {
                await Task.Run(async
                    () =>
                 {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Console.WriteLine("#####################################################################");
                     TestAsyncLocal.Instance.SetAsyncLocalString($"第{i}個");
                     //Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}',CurrentCulture:{3},CurrentUICulture:{4},ManagedThreadId:{5},IsBackground:{6},IsThreadPoolThread:{7}",
                     //         $"第{i}個", TestAsyncLocal.Instance.AsyncLocalString, TestAsyncLocal.Instance.AsyncLocalString, Thread.CurrentThread.CurrentCulture,
                     //         Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
                     await Task.Delay(100);
                     Console.WriteLine("-------------------------------------------------------------------------");
                     TestAsyncLocal.Instance.SetAsyncLocalString($"第{i + 1}個");
                     //Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}',CurrentCulture:{3},CurrentUICulture:{4},ManagedThreadId:{5},IsBackground:{6},IsThreadPoolThread:{7}",
                     //         $"第{i}個", TestAsyncLocal.Instance.AsyncLocalString, TestAsyncLocal.Instance.AsyncLocalString, Thread.CurrentThread.CurrentCulture,
                     //         Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
                     ExecutionContext.Run(
                ec,
                _ =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("**************************************************************************");
                    TestAsyncLocal.Instance.SetAsyncLocalString($"ExecutionContext{i+2}個");
                    Console.WriteLine("  ExecutionContext CurrentCulture:{0},CurrentUICulture:{1},ManagedThreadId:{2},IsBackground:{3},IsThreadPoolThread:{4}",
                            Thread.CurrentThread.CurrentCulture,
                           Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);
                },
                null);
                 });
            }
            //Parallel.For(1, 10, (index) =>
            //{
            //    TestAsyncLocal.Instance.SetAsyncLocalString($"第{index}個");
            //    TestAsyncLocal.Instance.NormalString = $"第{index}個";
            //    Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}',CurrentCulture:{3},CurrentUICulture:{4},ManagedThreadId:{5},IsBackground:{6},IsThreadPoolThread:{7}",
            //             $"第{index}個", TestAsyncLocal.Instance.AsyncLocalString, TestAsyncLocal.Instance.NormalString, Thread.CurrentThread.CurrentCulture,
            //             Thread.CurrentThread.CurrentUICulture, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread);

            //});
        }
    }
}
