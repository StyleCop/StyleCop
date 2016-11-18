using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class DocumentationProperties
    {
        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public bool ValidProperty1
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public Dictionary<int[], bool?> ValidProperty2
        {
            get { return null; }
        }

        /// <summary>
        /// Sets a whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public Dictionary<int[], bool?> ValidProperty3
        {
            set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public Dictionary<int[], bool?> ValidProperty4
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public Dictionary<int[], bool?> ValidProperty5
        {
            get { return null; }
            internal set { }
        }

        /// <summary>
        /// Gets or sets the whatever.
        /// </summary>
        /// <value>This is the value.</value>
        internal Dictionary<int[], bool?> ValidProperty6
        {
            get { return null; }
            protected set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <value>This is the value.</value>
        protected Dictionary<int[], bool?> ValidProperty7
        {
            get { return null; }
            private set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <value>This is the value.</value>
        protected internal Dictionary<int[], bool?> ValidProperty8
        {
            get { return null; }
            private set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <value>This is the value.</value>
        private Dictionary<int[], bool?> ValidProperty9
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <value>This is the value.</value>
        public static Dictionary<int[], bool?> ValidProperty10
        {
            get { return null; }
            set { }
        }

        /// <summary>Gets or sets a whatever.</summary><value>This is the value.</value>
        public int ValidProperty11
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <remarks>Adding a remarks tag.</remarks>
        /// <value>This is the value.</value>
        public string ValidProperty12
        {
            get { return null; }
        }

        /// <summary>
        /// Summary description for property.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty1
        {
            get { return 1; }
        }

        /// The property's xml is invalid. Missing opening summary tag.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty2
        {
            get { return 1; }
        }

        public int InvalidProperty3
        {
            get { return 1; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty4
        {
            get { return 1; }
        }

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty5
        {
            get { return 1; }
        }

        /// <summary>
        /// Short.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty6
        {
            get { return 1; }
        }

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty7
        {
            get { return 1; }
        }

        /// <summary>
        /// gets no capital letter.
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty8
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets no closing period
        /// </summary>
        /// <value>This is the value.</value>
        public int InvalidProperty9
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        public int InvalidProperty10
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value></value>
        public int InvalidProperty11
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>Nospaceshereatall.</value>
        public int InvalidProperty12
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>Short.</value>
        public int InvalidProperty13
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</value>
        public int InvalidProperty14
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>no capital letter.</value>
        public int InvalidProperty15
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>No closing period</value>
        public int InvalidProperty16
        {
            get { return 1; }
        }

        /////// <summary>
        /////// Gets a line that is copied.
        /////// </summary>
        /////// <value>Gets a line that is copied.</value>
        ////public int InvalidProperty17
        ////{
        ////    get { return 1; }
        ////}

        internal int InvalidProperty18
        {
            get { return 1; }
        }

        protected int InvalidProperty19
        {
            get { return 1; }
        }

        protected internal int InvalidProperty20
        {
            get { return 1; }
        }

        private int InvalidProperty21
        {
            get { return 1; }
        }

        public static int InvalidProperty22
        {
            get { return 1; }
        }

        /// <summary>
        /// Omits the get wording.
        /// </summary>
        public int InvalidProperty23
        {
            get { return 1; }
        }
        
        /// <summary>
        /// Omits the set wording.
        /// </summary>
        public int InvalidProperty24
        {
            set { }
        }

        /// <summary>
        /// Omits the get and set wording.
        /// </summary>
        public int InvalidProperty25
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Gets the (omits the set wording).
        /// </summary>
        public int InvalidProperty26
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Sets the (omits the get wording).
        /// </summary>
        public int InvalidProperty27
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        public int InvalidProperty28
        {
            get { return 1; }
            internal set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is private).
        /// </summary>
        public int InvalidProperty29
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// Gets or sets the whatever.
        /// </summary><value>This is a value.</value>
        public int ValidPropertyXXXX
        {
            get { return 1; }
            protected set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is private).
        /// </summary>
        protected int InvalidProperty31
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        protected internal int InvalidProperty32
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <remarks></remarks>
        /// <value>This is the value.</value>
        public string InvalidProperty33
        {
            get { return null; }
        }
    }

    /// <summary>
    /// An internal class.
    /// </summary>
    internal class InternalClass
    {
        /// <summary>
        /// Gets or sets the whatever.
        /// </summary>
        public string Property
        {
            get { return null; }
            set { } 
        }

        /// <summary>
        /// Gets or sets the whatever.
        /// </summary>
        public string Property2
        {
            get { return null; }
            protected set { }
        }

        /// <summary>
        /// Gets or sets the whatever (property is implicitly internal so include the intrenal accessor too).
        /// </summary>
        public string Property3
        {
            get { return null; }
            internal set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        public string Property4
        {
            get { return null; }
            private set { }
        }

        /// <summary>
        /// Gets or sets the whatever (property is implicitly protected AND internal so include the internal accessor too).
        /// </summary>
        protected string Property3
        {
            get { return null; }
            internal set { }
        }
    }

    /// <summary>
    /// This is the class summary. This class tests that <c></c> and <paramref name=""/> do not insist an capital letters.
    /// </summary>
    public class DocumentationProperties2
    {
        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <remarks><c>true</c> or false.</remarks>
        /// <value>This is the value.</value>
        public string ValidProperty1
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        /// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>        
        public bool ValidProperty2
        {
            get { return true; }
        }
        
        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value><paramref name="value"/> this is the value.</value>
        public int ValidProperty3
        {
            get { return 1; }
        }
                
        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <value>no capital letter.</value>
        public int InvalidProperty1
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        /// <value>true if valid; otherwise, false.</value>        
        public bool InvalidProperty2
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether whatever.
        /// </summary>
        /// <value>true if valid; <paramref name="value"/> otherwise, false.</value>        
        public bool InvalidProperty3
        {
            get { return true; }
        }
    }
}



 