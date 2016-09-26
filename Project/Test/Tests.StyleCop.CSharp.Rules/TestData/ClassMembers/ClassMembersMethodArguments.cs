using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData.ClassMembers
{
    class ClassMembersMethodArguments
    {
        private int x;
        private string y;

        public void MethodToCall(int x, string y)
        {
        }

        public void TestMethodCalls()
        {
            this.MethodToCall(this.x, this.y);
            this.MethodToCall(x, this.y);
            this.MethodToCall(this.x, y);
            this.MethodToCall(x, y);
            MethodToCall(this.x, this.y);
            MethodToCall(x, this.y);
            MethodToCall(this.x, y);
            MethodToCall(x, y);

            Console.WriteLine(this.y, this.x);
            Console.WriteLine(y, this.x);
            Console.WriteLine(this.y, x);
            Console.WriteLine(y, x);

            Console.WriteLine(y, x).Clone();
            Console.WriteLine(this.y, this.x).Clone(this.x);
            Console.WriteLine(this.y, this.x).Clone(x);
            Console.WriteLine(this.y, this.x).Clone(x).Clone();
            Console.WriteLine(this.y, this.x).Clone().Clone(x);
        }
    }
}
