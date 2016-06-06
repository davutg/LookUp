using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class AsyncAwaitTest
    {
        const int loopCount = 10000;
        public async Task<bool> DoAnAsyncCall() {
            bool result= await Task<bool>.Run(() => {
                for (int i = 0; i < loopCount; i++)
                {
                    ((Action)(() => { int x = i ^ 2; Debug.WriteLineIf(x % 4001 == 0, x.ToString()); }))();
                }                
                return true;
            });
            return result;
         
        }

        public bool DoCall()
        {
            for (int i = 0; i < loopCount; i++)
            {
                ((Action)(() => { int x = i ^ 2; Debug.WriteLineIf(x % 4001 == 0,x.ToString()); }))();                
            }
            return true;
        }         
    }
}
