using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.ValidPrefixes
{
    public class Class1
    {
        public bool A<T>()
        {
            return B<T>(); // should throw 1101
        }

        private bool B<T>()
        {
            return true;
        }
    }

    public class Class2
    {
        public bool A<T>()
        {
            return B(); // should throw 1101
        }

        private bool B()
        {
            return true;
        }
    }

    public class Class3
    {
        public void A1<T>(T value)
        {
        }

        public virtual void A2<T>(T value)
        {
        }
    }

    //// 1100 - don't use base (only use base if virtual in base class and overridden locally or declared new locally)
    //// 1101 - must use this
    //// 11nn - use this or base 
    /*

    when checking base (must have a BaseClass specified) -
      
    if the method call is 'A1<T>' look for:
      (a method on base class called 'A1<T>' marked virtual AND local method A1 marked override) OR
      method on this class called 'A1<T>' marked new. If found then base is ok.

     ( 'override A1' OR 'new A1<T>' )
     if found base is ok
     
    if the method call is 'A1' look for:
      (a method on base class called 'A1<T>' or 'A1' marked virtual AND local method A1 marked override) OR
      (method on this class called 'A1<T>' marked new) OR 
      (A1<T> on base not virtual AND A1 on this class) OR
      (A1<T> on base not virtual AND A1<T> override on this class)
     If found then base is ok.

     ( 'override A1' OR 'new A1<T>' OR 'override A1<T>' OR 'A1' )
     If found then base is ok.


    if the method call is like 'A1<int>' look for:
      (a method on base class called 'A1<T>' marked virtual AND local method A1 marked override) OR
      method on this class called 'A1'. If found base is ok.

     ( 'override A1' OR 'A1' ) 
     If found then base is ok.
     
     otherwise not needed.
      
    
    when checking for this or base (must have a BaseClass specified):
      
      
     if the method call is like 'A1<T>' look for a method on base class called 'A1<T>' marked virtual OR
     method on this class called 'A1<T>' marked new. If found then 'base or this' are required. 
     
     * ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
    
     
    if the method call is like 'A1' look for a method on base class called 'A1<T>' or 'A1' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this'  is required.

     ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
    
    
     if the method call is like 'A1<int>' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this' are required.
 
     ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
     
      
     if the method call is like 'A1' look for a method on base class called 'A1<T>' or 'A1' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this'  is required.
     if the method call is like 'A1' look for a method on base class called 'A1<T>' AND
      method on this class called 'A1'. If found then 'base or this'  is required.
  
     ( 'new  A1<T>' OR ' not new not override A1' ) 
     throw 'ThisOrBaseRequired'
     
      
      
      
     when checking for 'this' (no BaseClass specified):
     
     if the method call is 'A1<int>' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>'. If both not found then 'this' is required.

     ( ! 'A1<T>' )
     * then this is required
      
      if the method call is 'A1' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>' or 'A1'. If both not found then 'this' is required.

     ( ! 'A1<T>' || ! 'A1' ) 
     * this is required
      
     
    
      
    
     Equals, ReferenceEquals and static methods
     
    */



    public class Class4 : Class3
    {
        public new void A1<T>(T value)
        {
            this.A1(value);    // should not throw 1100 or 1101 - calling the local method.
            base.A1(value);    // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A1<T>(value);      // needs 'this or base' - calling the local method. (but could call base)
            A1(value);         // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class5 : Class3
    {
        public void A1(int value)
        {
            this.A1(value);      // should not throw 1100 or 1101 - calling the local method.
            base.A1(value);      // should not throw 1100 or 1101 - calling the base method.
            this.A1<int>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<int>(value); // should not throw 1100 or 1101 - calling the base method.
            A1<int>(value);      // needs 'this or base' - calling the local method.
            A1(value);           // needs 'this or base' - calling the local method.
        }

        public new void A1<T>(T value)
        {
            this.A1(value);      // should not throw 1100 or 1101 - calling the local method.
            base.A1(value);      // should not throw 1100 or 1101 - calling the base method.
            this.A1<T>(value);   // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value);   // should not throw 1100 or 1101 - calling the base method.
            A1<T>(value);        // needs 'this or base' - calling the local method.
            A1(value);           // needs 'this or base' - calling the local method.
        }
    }

    public class Class6 : Class3
    {
        public void A1(int value)
        {
            this.A1(value);      // should not throw 1100 or 1101 - calling the local method.
            base.A1(value);      // should not throw 1100 or 1101 - calling the base method.
            this.A1<int>(value); // should not throw 1100 or 1101 - calling the only method.
            base.A1<int>(value); // should throw 1100 swap base to this - calling the only method. *** CAN'T DETECT THIS ***
            A1<int>(value);      // should throw 1101 needs 'this' - calling the only method.
            A1(value);           // needs 'this or base' - calling the local method.
            A1<bool>(true);      // should throw 1101 needs 'this' - calling the only method.
        }
    }

    public class Class7 : Class3
    {
        public new void A1<T>(T value)
        {
        }

        public override void A2<T>(T value)
        {
            this.A1(value);    // should not throw 1100 or 1101 - calling the base method.
            base.A1(value);    // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A1<T>(value);      // needs 'this or base' - calling the local method. (but could call base)
            A1(value);         // needs 'this or base' - calling the local method. (but could call base)

            this.A2(value);    // should not throw 1100 or 1101 - calling the local method.
            base.A2(value);    // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A2<T>(value);      // needs 'this or base' - calling the local method. (but could call base)
            A2(value);         // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class8 : Class3
    {
        public override void A2<T>(T value)
        {
            this.A1(value);    // should not throw 1100 or 1101 - calling the base method.
            base.A1(value);    // should throw 1100 (base not required) - calling the base method. 
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the only method.
            base.A1<T>(value); // should throw 1100 (base not required) - calling the only method.
            A1<T>(value);      // should throw 1101 needs 'this' - calling the only method.
            A1(value);         // should throw 1101 needs 'this' - calling the only method.

            this.A2(value);    // should not throw 1100 or 1101 - calling the local method.
            base.A2(value);    // should not throw 1100 or 1101 - calling the base method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2<T>(value); // should not throw 1100 or 1101 - calling the base method.
            A2<T>(value);      // needs 'this or base' - calling the local method. (but could call base)
            A2(value);         // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class9
    {
        public void A2<T>(T value)
        {
            this.A2(value);    // should not throw 1100 or 1101 - calling the local method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            A2<T>(value);      // should throw 1101 needs 'this' - calling the only method.
            A2(value);         // should throw 1101 needs 'this' - calling the only method.
        }
    }

    

        /// <summary>
        /// The class 75.
        /// </summary>
        internal class Class75
        {
            #region Fields

            /// <summary>
            /// The dictionary.
            /// </summary>
            private Dictionary<int, string> dictionary;

            /// <summary>
            /// The variable.
            /// </summary>
            private IList<int> variable;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="Class75"/> class.
            /// </summary>
            public Class75()
            {
                this.dictionary = new Dictionary<int, string>();
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets Property.
            /// </summary>
            /// <value>
            /// The property. 
            /// </value>
            public IList<int> Property
            {
                get
                {
                    return (IList<int>)this.variable;
                }
            }

            public Dictionary<int, string> Dictionary
            {
                get
                {
                    return (Dictionary<int, string>)this.dictionary;
                }
            }

            #endregion
        }
    }

}
