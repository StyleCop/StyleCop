using System;
using System.Collections.Generic;

// The following uses of the built-in types are alias within using alias directives.
using BooleanAlias = System.Boolean;
using ByteAlias = System.Byte;
using CharAlias = System.Char;
using DecimalAlias = System.Decimal;
using DoubleAlias = System.Double;
using Int16Alias = System.Int16;
using Int32Alias = System.Int32;
using Int64Alias = System.Int64;
using ObjectAlias = System.Object;
using SingleAlias = System.Single;
using SByteAlias = System.SByte;
using StringAlias = System.String;
using UInt16Alias = System.UInt16;
using UInt32Alias = System.UInt32;
using UInt64Alias = System.UInt64;

// The following uses of the built-in types are alias within using static directives.
using static System.Boolean;
using static System.Byte;
using static System.Char;
using static System.Decimal;
using static System.Double;
using static System.Int16;
using static System.Int32;
using static System.Int64;
using static System.Object;
using static System.Single;
using static System.SByte;
using static System.String;
using static System.UInt16;
using static System.UInt32;
using static System.UInt64;

namespace ValidBuildInTypes
{
    #region The base class of a class or interface.
    
    public class Class1 : List<bool>
    {
    }

    public interface Interface1 : IList<int>
    {
    }

    #endregion 

    #region Implemented interfaces on a class or interface

    public class Class2 : Class1, IList<string>
    {
    }

    public interface Interface2 : Interface1, IList<short>
    {
    }

    #endregion

    #region Type constraint clauses on a class, interface, struct, method, or delegate

    public class Class3<T, S> 
        where T : bool 
        where S : List<List<bool>>
    {
    }

    public interface Interface3<T, S> 
        where T : byte 
        where S : List<List<byte>>
    {
    }

    public struct Struct3<T, S> 
        where T : float 
        where S : List<List<float>>
    {
    }

    public delegate void Delegate1<T, S>(T x) 
        where T : double 
        where S : List<List<double>>;

    public class Class3b
    {
        public void Method3<T, S>(T x)
            where T : long
            where S : List<List<long>>
        {
        }
    }

    #endregion 

    #region Parameter list on method, indexer, constructor, or delegate

    public class Class4
    {
        public void Method(bool x, Dictionary<bool, List<List<bool>>> y)
        {
        }

        public int this[string x, Dictionary<string, List<List<string>>> y]
        {
            get { return 2; }
        }

        public Class4(object x, Dictionary<object, List<List<object>>> y)
        {
        }

        public delegate void Delegate4(char x, Dictionary<char, List<List<char>>> y);
    }

    #endregion 

    #region Parameter list on anonymous method and lambda expression

    public class Class10
    {
        public void Method1()
        {
            CallMethod(delegate(short x, int y)
            {
                int z = 2;
            });

            CallMethod2((short x, int y) => { int z = 2; });
        }
    }

    #endregion

    #region Return type on method, indexer, property, delegate, or event

    public class Class5
    {
        public Dictionary<decimal, List<List<decimal>>> Method5()
        {
        }

        public Dictionary<sbyte, List<List<sbyte>>> this[sbyte x]
        {
            get { return null; }
        }

        public Dictionary<ulong, List<List<ulong>>> Property5
        {
            get { return null; }
        }

        public delegate Dictionary<uint, List<List<uint>>> Delegate5();

        public event EventHandler<Dictionary<byte, List<List<byte>>>> Event5;
    }

    #endregion 

    #region Type of Field

    public class Class6
    {
        private ulong field1;
        private ulong field2;
        private const ulong field3 = 0;
        private const ulong field4 = null;
        private readonly ulong field5;
        private readonly ulong field6;
    }

    #endregion 

    #region Generic types on class, interface, struct, method, or delegate

    public class Class7
    {
        public void Method1()
        {
            object x = new Dictionary<string, Dictionary<List<string>, string>, string>();
            object y = (IList<Dictionary<string, Dictionary<List<string>, string>>, string>)x;

            CallSomeMethod<Dictionary<string, Dictionary<List<string>, string>>, string>();
        }
    }

    #endregion

    #region Statements

    public class Class9
    {
        public void Method1()
        {
            // for statement
            for (long x = 0; x < 1; ++x)
            {
            }

            // foreach statement
            foreach (object o in Something())
            {
            }

            // try-catch
            try
            {
            }
            catch (SomeException<object> e)
            {
            }

            // Fixed statement
            fixed (int x = 0)
            {
            }

            // throw new 
            throw new SomeException<char>();

            // using statement
            using (object o = null)
            {
            }

            // new allocation
            Dictionary<List<bool>, string> dict = new Dictionary<List<bool>, string>();

            // new array
            string[] array = new string[3];
        }
    }

    #endregion Statements

    #region Expressions

    public class Class11
    {
        public void Method1()
        {
            // As expression
            object z = null;
            object x = z as List<List<string>>;
            
            // Is expression
            bool t = z is List<List<string>>;

            // Cast expression
            object a = null;
            object b = (string)a;

            // Default value
            object c = default(byte);

            // Sizeof
            int d = sizeof(object);

            // Typeof
            Type e = typeof(char);
        }
    }

    #endregion

    #region Query Expressions

    public class Class12
    {
        public void Method1()
        {
            object a;

            from string s in a where s.Length == 2 select s.Length;
        }
    }

    #endregion

    #region Method Access Expressions

    public class Class13
    {
        public void Method1()
        {
            string c = string.Format("");

            object o = object.Equals(a, b);
        }
    }

    #endregion
}