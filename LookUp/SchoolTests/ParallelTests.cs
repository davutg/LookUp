using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLib;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

namespace SchoolTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoesParallelTestWork()
        {
            TimeSpan d1=default(TimeSpan), d2=default(TimeSpan);
            ParallelTests test = new ParallelTests();
            #region Use of LINQ PARALLEL                                   
            Action a1=()=>{
                var m1 = test.LoopNumbersParallel();
                Debug.WriteLine("parallel" + m1);
                d1 = m1;
            };

            Action a2 = () => {
                var m2 = test.LoopNumbers();
                Debug.WriteLine("single thread" + m2);
                d2 = m2;
            };

            List<Action> tests = new List<Action>() {a1,a2};
            var testsParallel = tests.AsParallel();
            Debug.WriteLine(DateTime.Now);
            testsParallel.ForAll((a) =>
            {
                a();
            });
            #endregion
            Assert.IsTrue(d2 > d1);
            Debug.WriteLine(string.Format("Single:{0},Parallel:{1} ,dif:{2}", d2.Milliseconds, d1.Milliseconds,(d2-d1).Milliseconds));
        }
    }
}
