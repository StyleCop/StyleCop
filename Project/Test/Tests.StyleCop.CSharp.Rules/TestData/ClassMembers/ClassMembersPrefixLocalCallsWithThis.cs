namespace CSharpAnalyzersTest.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PrefixLocalCallsWithThis
    {
        private int memberField;
        
        private readonly int memberReadonlyField = 0;

        private int MemberProperty
        {
            get
            {
                return 0;
            }

            set
            {
            }
        }

        private int MemberMethod()
        {
            return 0;
        }

        private event MemberDelegate MemberEvent;

        private const int MyConst = 0;

        private static int myStaticField;

        private static int MyStaticProperty
        {
            get
            {
                return 0;
            }

            set
            {
            }
        }

        private static int MyStaticMethod()
        {
        }

        private delegate void MyDelegate();
        
        private enum MyEnum
        {
            MyEnumValue
        }

        private class MyClass
        {
        }

        private struct MyStruct
        {
        }

        // Omit the this. prefixes.
        public void TestMissingMembers()
        {
            int w = memberField;

            int x = memberReadonlyField;

            int y = MemberProperty;
            MemberProperty = 2;

            int z = MemberMethod();

            if (MemberEvent != null)
            {
                // whatever.
            }
        }

        // Include the this. prefixes.
        public void TestIncludedMembers()
        {
            int w = this.memberField;

            int x = this.readonlyMemberField;

            int y = this.MemberProperty;
            this.MemberProperty = 2;

            int z = this.MemberMethod();

            if (this.MemberEvent != null)
            {
                // whatever.
            }
        }

        // Call the other members which do not require this.
        public void TestOtherMembers()
        {
            int a = MyConst;
            int b = myStaticField;
            int c = MyStaticProperty;
            MyStaticProperty = 2;
            int d = MyStaticMethod();

            MyDelegate e = null;

            MyEnum f = MyEnum.MyEnumValue;

            MyClass g = new MyClass();

            MyStruct h = new MyStruct();
        }

        private int intField = 0;
        private int IntProperty
        {
            get { return this.intField; }
            set { this.intField = value; }
        }

        public void TestIncrementDecrement()
        {
            // Correct.
            ++this.intField;
            this.intField++;
            --this.intField;
            this.intField--;

            ++this.IntProperty;
            this.IntProperty++;
            --this.IntProperty;
            this.IntProperty--;

            // Incorrect
            ++intField;
            intField++;
            --intField;
            intField--;

            ++IntProperty;
            IntProperty++;
            --IntProperty;
            IntProperty--;
        }
    }

    public class TestAnonymousTypes
    {
        public string FirstName
        {
            get;
            set;
        }

        public void CreateAnonymousType()
        {
            var anonymousType = new
            {
                // The item on the right-hand side should start with this since it refers to the local property. The item on the
                // left hand side should not start with this since it refers to a property on the anonymous type. We split the 
                // assignment statement across multiple lines in this test code so we can see which of the items is being flagges
                // as a violation, and which is not.
                FirstName 
                = 
                FirstName
            };
        }
    }

    public class TestNestedMemberAccessAndMethodInvocationCalls
    {
        public int a;

        public void Method1(int x)
        {
        }

        public void Method2()
        {
            // Trigger on Method1.
            Method1(a.Length);

            // Trigger on Method1.
            Method1(a.Length).Clone();

            // Trigger on a.
            NonExistantMethod(a.Length);

            // Trigger on a.
            NonExistantMethod(a.Length).Clone();

            // Trigger on a.
            NonExistantMethod(2).Something(a);
        }
    }
}
