using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace SchoolLib
{
    public class ParallelTests
    {
        Dictionary<int, int> tasks = new Dictionary<int, int>();
        int topNumber = 100000;
        public TimeSpan LoopNumbersParallel()
        {
            var now = DateTime.Now;        
            var numbers = Enumerable.Range(0, topNumber);
            var job = from n in numbers.AsParallel()
                      select n;
            job.ForAll((x) =>
            {
                string info =string.Format("Task number:{0}, value:{1}", System.Threading.Tasks.Task.CurrentId.Value, x);                
            });
            return DateTime.Now-now;
        }

        public TimeSpan LoopNumbers()
        {
            var now = DateTime.Now;
            var numbers = Enumerable.Range(0, topNumber);
            var job = from n in numbers
                      select n;
            foreach (var x in job)
            {
                string info = string.Format("Task number:{0}, value:{1}", System.Threading.Tasks.Task.CurrentId.Value, x);
            }

            return DateTime.Now - now;
        }

        public static void main(string[] args)
        {
            ParallelTests tests = new ParallelTests();
            tests.LoopNumbersParallel();
        }

    }
}
