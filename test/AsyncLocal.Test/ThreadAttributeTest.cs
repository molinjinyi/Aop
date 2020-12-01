using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AsyncLocal.Test
{
   public  class ThreadAttributeTest
    {
        private int _balance = 1000;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void WithDraw()
        {
            var money = _balance - 100;
        }
    }
}
