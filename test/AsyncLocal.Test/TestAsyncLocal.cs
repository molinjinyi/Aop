using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AsyncLocal.Test
{
    public class TestAsyncLocal
    {
        public static TestAsyncLocal Instance = new TestAsyncLocal();
        private AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>();

        public string NormalString { get; set; }

        private TestAsyncLocal() { }


        public string AsyncLocalString => _asyncLocalString.Value;


        public void SetAsyncLocalString(string value)
        {
            _asyncLocalString.Value = value;
        }
    }
}
