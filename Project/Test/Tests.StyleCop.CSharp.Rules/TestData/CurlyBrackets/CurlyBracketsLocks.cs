using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsLocks
    {
        public void TestLocks()
        {
            int x;
            object y;

            // Invalid locks
            lock (y) { }
            lock (y) { x = 2; }

            lock (y) 
            { 
                x = 2; }

            lock (y) {
                x = 2; 
            }

            lock (y) {
                x = 2; } 

            lock (y) 
            { x = 2; 
            }

            lock (y) 
            { x = 2; }

            // Valid locks
            lock (y) 
            { 
            }

            lock (y) 
            { 
                x = 2; 
            }
        }
             
        private void MethodName(string x)
        {
            lock (y)
                x = x.Substring(1);
        }
    }
}