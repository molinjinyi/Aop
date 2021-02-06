//using System;
//using System.Buffers;
//using System.Diagnostics;
//using System.Text.RegularExpressions;
//using System.Threading;

//namespace TimerTest
//{
//    class Program
//    {
//        private readonly static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
//        private static int _count = 0;
//        static void Main(string[] args)
//        {
//            var regex= new Regex("User.+?", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
//            if (regex.IsMatch("UserGroupByUserId_"))
//            { 
            
//            }
//            var bookPool = ArrayPool<Book>.Create();
//            var timer = new Timer((a) =>
//            {
//                _count++;
//                Console.WriteLine(_count);
//                if (_count > 100000) autoResetEvent.Set();

//                var books = bookPool.Rent(2);


//                books[0].Name = _count.ToString();
//                Console.WriteLine($"Book.Count:{Book.Count}");
//                Console.WriteLine($"Book.Name:{books[0].Name}");
//            }, null, Timeout.Infinite, Timeout.Infinite);
//            Debug.Assert(1 == 2);
//            timer.Change(100, 200);
//            autoResetEvent.WaitOne();
//            Console.WriteLine(autoResetEvent.WaitOne(20000));
            
//        }
//    }
//    public static class ExceptionUtils {

//        public static void ThrowExceptionIfNull(object obj, string? paramName, string message)
//        {
//            if (obj == null)
//                throw new ArgumentNullException(paramName,message);
//        }
     
//    }

//    public struct Book {
//        private static int _count;
        

//        public static int Count { get => _count; set => _count = value; }

//        public string Name { get; set; }
//    }


   
//}
