using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsDelegates
    {
        private void TestDelegates()
        {
            // Valid anonymous methods or delegates.
            MethodInvocationHandler item = delegate { };
            MethodInvocationHandler item2 = delegate { int x; };
            // Invalid anonymous methods or delegates.
            MethodInvocationHandler item3 = delegate 
            { 
                int x; };

            MethodInvocationHandler item = delegate { 
                int x; 
            };

            MethodInvocationHandler item = delegate {
                int x; };

            MethodInvocationHandler item = delegate 
            { 
                int x; };

            MethodInvocationHandler item = delegate
            { int x;
            };

            MethodInvocationHandler item = delegate
            { int x; };

            this.Method(delegate
            {
                int x; });

            this.Method(delegate {
                int x;
            });

            this.Method(delegate {
                int x; });

            this.Method(delegate
            {
                int x; });

            this.Method(delegate
            { int x;
            });

            this.Method(delegate
            { int x; });

            // Valid anonymous methods or delegates.
            MethodInvocationHandler item = delegate 
            { 
            };

            MethodInvocationHandler item = delegate 
            {
                int x;
            };

            this.Method(delegate { int x; });

            this.Method(delegate 
            { 
                int x; 
            });
        }
    }
}