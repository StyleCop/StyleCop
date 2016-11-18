namespace Parenthesis1
{
    using System;

    public class Class1 : Class2
    {
        public void Valid()
        {
            // Arithmetic expression
            int a = 1 + (2 * 3);

            // As expression
            string b = (whatever as Class1).ToString();

            // Assignment expression
            string aa = (b = a.ToString()).ToString();

            // Cast expression
            string c = ((Class1)whatever).ToString();

            // Conditional expression
            int d = 2 + (1 == 2 ? 4 : 5);

            // Conditional logical expression
            bool e = (2 + 4 < 6 && true != false) || d == 5;

            // Decrement expression.
            string f = (d--).ToString();

            // Increment expression
            string g = (d++).ToString();

            // Is expression
            bool h = (whatever is Class1) != true;

            // Logical expression
            string i = (e & 2).ToString();

            // New expression
            string j = (new Class1()).SomeProperty;

            // New array expression
            int k = (new int[] { 2, 3, 4 }).Length;

            // Null coelescing expression
            string l = (j ?? "some string").Length;

            // Relational expression
            string m = (2 < 4).ToString();

            // Unary expression
            int m = (~4).ToString();

            // Query expression.
            var n = (from rol in svr.Elements("role") select rol.Value).ToArray();

            // It is also legal to chain together member accesses without any parenthesis.
            bool value = Class1.Class2.Class3.Class4.Property1;

            // It is legal to wrap a pointer access within a set of parenthesis.
            unsafe
            {
                SomeType type = (SomeType)(*p) & SomeType.TypeMask;
            }

            // It is legal to cast "this".
            object castThis = (object)this;

            // It is legal to cast "base".
            object castBase = (object)base;

            // It is legal to cast null.
            string castNull = (string)null;

            // It is legal to cast new.
            string castNew = (object)new object();

            // It is legal to cast a number.
            int castNumber = (int)6;

            // It is legal to cast a string.
            string castString = (string)"hello";

            // It is legal to cast a delegate.
            object castDelegate = (object)delegate(int x) { int y = 2; };

            // It is legal to cast typeof.
            object castTypeof = (object)typeof(int);

            // It is legal to cast sizeof.
            object castSizeof = (object)sizeof(int);

            // It is legal to cast default.
            object castDefault = default(castSizeof);

            // It is legal to cast true and false.
            object castTrue = (object)true;
            object castFalse = (object)false;

            // It is legal to cast checked and unchecked.
            object castChecked = (object)checked((short)1 + 2);
            object castUnchecked = (object)unchecked((short)1 + 2);

        
        }

        public void Invalid()
        {
            // Anonymous method expression
            EventHandler a = (delegate(object aa) { int bb = 2; });
            
            // Array access expression
            int[] b = { 1, 2 };
            string c = (b[0]).ToString();

            // Assignment expression
            int d;
            (d = 5);

            // Checked expression
            string e = (checked((short)(x + y))).ToString();
            string e2 = checked((x + y));
            string e3 = checked(((x + y)));

            // Unchecked expression
            string f = (unchecked((short)(x + y))).ToString();
            string f2 = unchecked((x + y));
            string f3 = unchecked(((x + y)));

            // Default value expression
            string g = (default(string)).ToString();

            // Lambda expression.
            EventHandler h = ((aa) => { int bb = 2; });

            // Literal expression.
            string i = (true).ToString();

            // Member access expression
            bool j = (((Class1.Class2).Class3).Class4).Property1;
            bool k = ((Class1.Class2.Class3).Class4).Property1;
            bool l = (Class1.Class2.Class3.Class4).Property1;

            // Method invocation expression.
            string m = (SomeMethod(2)).ToString();

            // Parenthesized expression
            int n = ((1 + 2)) / 4;

            // Sizeof expression
            string p = (sizeof(bool)).ToString();

            // Stackalloc expression
            unsafe
            {
                int* q = (stackalloc int[100]);
            }

            // Typeof expression
            string r = (typeof(bool)).ToString();

            // Unsafe access expression
            unsafe
            {
                string s = (x->b()).ToString();
            }
        }

        public void ValidAsChild()
        {
            // A parenthesized expression is allowed as a child of another expression.
            int a = 2 * ((1 + 2) / 4);
        }

        public int InvalidAsChild()
        {
            // A parenthesized expression is not allowed as a child of a statement.
            return ((1 + 2) / 4);
        }

        public int Lambdas()
        {
            // A lambda is not allowed when part of a variable declarator or an assignment expression.
            int x = ((x, y) => x = y);
            x = ((x, y) => x = y);

            // It is allowed when a sub-expression.
            MyMethod((Action<int, int>)((x, y) => x = y));

            x = a ?? (b => b.c);

            // It is not allowed when part of a return.
            return (b => b.c);
        }

        // Tests that all of the following casts are allowed.
        public void Casts()
        {
            object o;
            int i;

            var x1 = (object)o;
            var x2 = (object)((object)o);
            var x3 = (object)4;
            var x4 = (object)~4;
            var x5 = (object)!true;
            var x6 = (object)new object();
            var x7 = (object)sizeof(o);
            var x8 = (object)typeof(o);
            var x9 = (object)default(o);
            var xa = (object)checked(o);
            var xb = (object)unchecked(o);
            var xc = (object)this;
            var xd = (object)base;
            var xe = (object)null;
            var xf = (object)true;
            var xg = (object)false;
            var xh = (object)+2;
            var xi = (object)-2;
            var xj = (object)"hi";
            var xk = (object)delegate(int value) { int j = value; };
            var xl = (object)++i;
            var xm = (object)--i;

            unsafe
            {
                var xn = (IntPtr*)&rc.left;
            }
        }
        
        public void M(Action a)
        {
            M(a: () => Console.WriteLine());
        }

        private void InvalidMethodParameters(int paramName)
        {
            this.MethodName((3 + 4)); // invalid
        }

        private void Method2()
        {
            var number = ((Func<int>)(() => 5))(); // This is valid
        }

        public T GetInstance<T>(Version version, object connectionContext)
        {
            var contract = typeof(T);
            var key = "a";
            object factory = new string('c', 12);
            if (key == "a")
            {
                var a = ((Func<object, T>)factory)(connectionContext); // valid

                return ((Func<object, T>)factory)(connectionContext); //valid
            }
        }
  
        internal class TypeA
        {
            public int Field;
        }

        public TypeA Method3()
        {
            
        }

        public async Task Method2() 
        {

            TypeA result = await this.Method3;
            int field = result.Field;

            int field2 = (await this.Method3).Field; //valid

        }

    }
}
