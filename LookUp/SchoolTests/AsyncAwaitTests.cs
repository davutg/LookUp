using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLib;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SchoolTests
{
    [TestClass]
    public class AsyncAwaitTests
    {
        [TestMethod]
        public void DOES_ASYNC_FASTER()
        {
            AsyncAwaitTest aaTest = new AsyncAwaitTest();
            TimeSpan d1 = DateTime.Now.TimeOfDay;
            TimeSpan d2 = new TimeSpan(d1.Ticks);
            TimeSpan d3 = new TimeSpan(d1.Ticks);
            TimeSpan d4 = new TimeSpan(d1.Ticks);
            Task t1= aaTest.DoAnAsyncCall();
            d4 = DateTime.Now.TimeOfDay-d4;//Async call is done,assume a state machine created
            Task.WaitAll(t1);//wait until async Completed
            d2 = DateTime.Now.TimeOfDay-d2;
           
            d1 = DateTime.Now.TimeOfDay;
            var r2=aaTest.DoCall();
            d3 = DateTime.Now.TimeOfDay - d1;
            Debug.WriteLine(String.Format("Started at {0}:\r\nAsync took:{1}ms\r\nSync took:{2}ms\r\nAsync return in:{3}ms",d1,d2.Milliseconds,d3.Milliseconds,d4.Milliseconds));

            Assert.IsTrue(d4 < d2);
        }
    }
}
