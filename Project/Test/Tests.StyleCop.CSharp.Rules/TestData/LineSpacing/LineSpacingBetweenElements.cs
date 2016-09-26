extern alias A;
extern alias B;

extern alias C;

extern alias D;
using System;
using System.Collections;

using System.Collections.Generic;
using Something 
    = 
        System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.Win32;
namespace LineSpacingBetweenElements1
{
    class Class1
    {
        bool field1;

        bool field2;
        bool field3;
        /// <summary>
        /// Header.
        /// </summary>
        bool[] field4 = { true, false };
        bool[] field5 =
        { 
            true, 
            false 
        };
        bool[] field6;
        
        Class1()
        {
        }

        Class1(int x)
        {
        }
        Class1(bool x)
        {
        }
        /// <summary>
        /// Header.
        /// </summary>
        Class1(string x)
        {
        }
        delegate void Delegate1();

        delegate void Delegate2();
        delegate void Delegate3();
        /// <summary>
        /// Header.
        /// </summary>
        delegate void Delegate4();
        event EventHandler Event1;

        event EventHandler Event2;
        event EventHandler Event3;
        /// <summary>
        /// Header.
        /// </summary>
        event EventHandler Event4;
        int this[int index]
        {
        }

        int this[bool index]
        {
        }
        int this[string index]
        {
        }
        /// <summary>
        /// Header.
        /// </summary>
        int this[char index]
        {
        }
        void Method1()
        {
        }

        void Method2()
        {
        }
        void Method3()
        {
        }
        /// <summary>
        /// Header.
        /// </summary>
        void Method4()
        {
        }
        bool Property1
        {
            get
            {
                return true;
            }

            set
            {
            }
        }

        bool Property2
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
        bool Property3
        {
            get { return true; }
            set { }
        }
        enum Enum1
        {
            EnumItem1,
            EnumItem2,
            /// <summary>
            /// Comment.
            /// </summary>
            EnumItem3,

            EnumItem4
        }

        enum Enum2
        {
        }
        enum Enum3
        {
        }
        /// <summary>
        /// Header.
        /// </summary>
        enum Enum4
        {
        }
    }

    class Class2
    {
    }
    class Class3
    {
    }
    /// <summary>
    /// Header
    /// </summary>
    class Class4
    {
    }
    interface Interface1
    {
    }

    interface Interface2 { }
    interface Interface3 
    { 
    }
    /// <summary>
    /// Header
    /// </summary>
    interface Interface4 
    { 
    }
    struct Struct1
    {
    }

    struct Struct2 { }
    struct Struct3
    {
    }
    /// <summary>
    /// Header
    /// </summary>
    struct Struct4
    {
    }
}

namespace LineSpacingBetweenElements2
{
}
namespace LineSpacingBetweenElements3
{
}