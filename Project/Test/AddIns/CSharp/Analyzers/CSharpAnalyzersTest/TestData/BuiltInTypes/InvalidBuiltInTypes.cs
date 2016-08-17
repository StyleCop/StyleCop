using System;
using System.Collections.Generic;

namespace InvalidBuildInTypes
{
    #region The base class of a class or interface.

    public class Class1 : List<Boolean>
    {
    }

    public interface Interface1 : IList<System.Boolean>
    {
    }

    #endregion

    #region Implemented interfaces on a class or interface

    public class Class2 : Class1, IList<Object>
    {
    }

    public interface Interface2 : Interface1, IList<System.Object>
    {
    }

    #endregion

    #region Type constraint clauses on a class, interface, struct, method, or delegate

    public class Class3<T, S>
        where T : string
        where S : List<List<String>>
    {
    }

    public interface Interface3<T, S>
        where T : String
        where S : List<List<string>>
    {
    }

    public struct Struct3<T, S>
        where T : string
        where S : List<List<System.String>>
    {
    }

    public delegate void Delegate1<T, S>(T x)
        where T : Int16
        where S : List<List<short>>;

    public delegate void Delegate2<T, S>(T x)
        where T : short
        where S : List<List<Int16>>;

    public delegate void Delegate3<T, S>(T x)
        where T : short
        where S : List<List<System.Int16>>;

    public class Class3b
    {
        public void Method1<T, S>(T x)
            where T : uint
            where S : List<List<UInt16>>
        {
        }

        public void Method2<T, S>(T x)
            where T : UInt16
            where S : List<List<uint>>
        {
        }

        public void Method3<T, S>(T x)
            where T : uint
            where S : List<List<System.UInt16>>
        {
        }
    }

    #endregion

    #region Parameter list on method, indexer, constructor, or delegate

    public class Class4
    {
        public void Method1(Int32 x, Dictionary<int, List<List<bool>>> y)
        {
        }

        public void Method2(int x, Dictionary<int, List<List<Int32>>> y)
        {
        }

        public void Method3(int x, Dictionary<System.Int32, List<List<int>>> y)
        {
        }

        public void Method4(UInt32 x, Dictionary<uint, List<List<uint>>> y)
        {
        }

        public void Method5(uint x, Dictionary<uint, List<List<UInt32>>> y)
        {
        }

        public void Method6(uint x, Dictionary<System.UInt32, List<List<uint>>> y)
        {
        }

        public int this[Int64 x, Dictionary<long, List<List<long>>> y]
        {
            get { return 2; }
        }

        public int this[long x, Dictionary<Int64, List<List<long>>> y]
        {
            get { return 2; }
        }

        public int this[long x, Dictionary<long, List<List<System.Int64>>> y]
        {
            get { return 2; }
        }

        public int this[UInt64 x, Dictionary<ulong, List<List<ulong>>> y]
        {
            get { return 2; }
        }

        public int this[ulong x, Dictionary<UInt64, List<List<ulong>>> y]
        {
            get { return 2; }
        }

        public int this[ulong x, Dictionary<ulong, List<List<System.UInt64>>> y]
        {
            get { return 2; }
        }

        public Class4(double x, Dictionary<double, List<List<Double>>> y)
        {
        }

        public Class4(Double x, Dictionary<double, List<List<double>>> y)
        {
        }

        public Class4(double x, Dictionary<System.Double, List<List<double>>> y)
        {
        }

        public delegate void Delegate4(float x, Dictionary<Single, List<List<float>>> y);

        public delegate void Delegate5(float x, Dictionary<float, List<List<Single>>> y);

        public delegate void Delegate6(System.Single x, Dictionary<float, List<List<float>>> y);
    }

    #endregion

    #region Parameter list on anonymous method and lambda expression

    public class Class10
    {
        public void Method1()
        {
            CallMethod(delegate(Byte x, byte y)
            {
                System.Byte z = 2;
            });

            CallMethod2((sbyte x, SByte y) => { System.SByte z = 2; });
        }
    }

    #endregion

    #region Return type on method, indexer, property, delegate, or event

    public class Class5
    {
        public Dictionary<char, List<List<System.Char>>> Method5()
        {
        }

        public Dictionary<Char, List<List<char>>> this[char x]
        {
            get { return null; }
        }

        public Dictionary<System.Decimal, List<List<decimal>>> Property5
        {
            get { return null; }
        }

        public delegate Dictionary<decimal, List<List<Decimal>>> Delegate5();

        public event EventHandler<Dictionary<Object, List<List<object>>>> Event5;
    }

    #endregion

    #region Type of Field

    public class Class6
    {
        private Boolean field1;
        private System.Char field2;
        private const Byte field3 = 0;
        private const System.Int32 field4 = null;
        private readonly UInt64 field5;
        private readonly String field6;
    }

    #endregion

    #region Generic types on class, interface, struct, method, or delegate

    public class Class7
    {
        public void Method1()
        {
            object x = new Dictionary<string, Dictionary<List<String>, string>, string>();
            object y = (IList<Dictionary<string, Dictionary<List<string>, String>>, string>)x;

            CallSomeMethod<Dictionary<String, Dictionary<List<string>, string>>, string>();
        }
    }

    #endregion

    #region Statements

    public class Class9
    {
        public void Method1()
        {
            // for statement
            for (Int64 x = 0; x < 1; ++x)
            {
            }

            // foreach statement
            foreach (Object o in Something())
            {
            }

            // try-catch
            try
            {
            }
            catch (SomeException<Object> e)
            {
            }

            // Fixed statement
            fixed (Int32 x = 0)
            {
            }

            // throw new 
            throw new SomeException<System.Char>();

            // using statement
            using (System.Object o = null)
            {
            }

            // new allocation
            Dictionary<List<bool>, string> dict = new Dictionary<List<Boolean>, string>();

            // new array
            string[] array = new String[3];
        }
    }

    #endregion Statements

    #region Expressions

    public class Class11
    {
        public void Method1()
        {
            // As expression
            Object z = null;
            object x = z as List<List<String>>;

            // Is expression
            bool t = z is List<List<String>>;

            // Cast expression
            System.Object a = null;
            object b = (String)a;

            // Default value
            object c = default(Byte);

            // Sizeof
            int d = sizeof(Object);

            // Typeof
            Type e = typeof(Char);
        }
    }

    #endregion

    #region Query Expressions

    public class Class12
    {
        public void Method1()
        {
            Object a;

            from System.String s in a where s.Length == 2 select s.Length;
        }
    }

    #endregion    

    #region Method Access Expressions

    public class Class13
    {
        public void Method1()
        {
            var a = String.Format("");

            var b = System.String.Format(""); 

            object o = Object.Equals(a, b);

            object o = System.Object.Equals(a, b);
        }
    }

    #endregion  
}
