using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Violations
{
    public class SimpleClass
    {
        /// <summary>
        /// Initializes a new instance of the Simple2Class class.
        /// </summary>
        public SimpleClass()
        {
        }
    }

    public class SimpleClassWithCref
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClassW2ithCref" /> class.
        /// </summary>
        public SimpleClassWithCref()
        {
        }
    }

    public class SimpleClassWithCrefAndFalseGenerics1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClassWithCref&lt;&gt;" /> class.
        /// </summary>
        public SimpleClassWithCrefAndFalseGenerics1()
        {
        }
    }

    public class SimpleClassWithCrefAndFalseGenerics2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClassWithCref&lt;>" /> class.
        /// </summary>
        public SimpleClassWithCrefAndFalseGenerics2()
        {
        }
    }

    public class SimpleClassWithCrefAndFalseGenerics3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClassWithCref{}" /> class.
        /// </summary>
        public SimpleClassWithCrefAndFalseGenerics3()
        {
        }
    }

    public class SimpleClassWithCrefAndFalseGenerics4
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SimpleClassWithCref`1" /> class.
        /// </summary>
        public SimpleClassWithCrefAndFalseGenerics4()
        {
        }
    }

    public class SimpleClassWithGenericsButNoCRef1<T>
    {
        /// <summary>
        /// Initializes a new instance of the SimpleClassWithGenericsButNoCRef1&lt;T&gt; class.
        /// </summary>
        public SimpleClassWithGenericsButNoCRef1()
        {
        }
    }

    public class SimpleClassWithGenericsButNoCRef2<T>
    {
        /// <summary>
        /// Initializes a new instance of the SimpleClassWithGenericsButNoCRef2&lt;T> class.
        /// </summary>
        public SimpleClassWithGenericsButNoCRef2()
        {
        }
    }

    public class SimpleClassWithGenericsButNoCRef3<T>
    {
        /// <summary>
        /// Initializes a new instance of the SimpleClassWithGenericsButNoCRef3{T} class.
        /// </summary>
        public SimpleClassWithGenericsButNoCRef3()
        {
        }
    }

    public class SimpleClassWithGenericsButNoCRef4<T>
    {
        /// <summary>
        /// Initializes a new instance of the T:SimpleClassWithGenericsButNoCRef4`1 class.
        /// </summary>
        public SimpleClassWithGenericsButNoCRef4()
        {
        }
    }

    public class SimpleClassWithNamespace
    {
        /// <summary>
        /// Initializes a new instance of the CSharpAnalyzersTest. TestData.SimpleClassWithNamespace class.
        /// </summary>
        public SimpleClassWithNamespace()
        {
        }
    }

    public class SimpleClassWithNamespaceAndCref
    {
        /// <summary>
        /// Initializes a new instance of the <se ecref="CSharpAnalyzersTest.TestData.SimpleClassWithNamespaceAndCref" /> class.
        /// </summary>
        public SimpleClassWithNamespaceAndCref()
        {
        }
    }

    public class SingleGenericClass<T>
    {
        /// <summary>
        /// Initializes a new instance of the SingleGenericClass{T,S} class.
        /// </summary>
        public SingleGenericClass()
        {
        }
    }

    public class SingleGenericClassWithNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of theCSharpAnalyzersTest.TestData.SingleGenericClassWithNamespace class.
        /// </summary>
        public SingleGenericClassWithNamespace()
        {
        }
    }

    public class SingleGenericClassWithMultiCharParam<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the SingleGenericClassWithMultiCharParam struct.
        /// </summary>
        public SingleGenericClassWithMultiCharParam()
        {
        }
    }

    public class SingleGenericClassCrefWithltgt<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWith&lt;T&gt;" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgt()
        {
        }
    }

    public class SingleGenericClassCrefWithltgtAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithltgtAndNamespace&lt;Z&gt;" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgtAndNamespace()
        {
        }
    }

    public class SingleGenericClassCrefWithltgtAndMultiCharParam<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithltgtAndMultiCharParam>TItem>" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgtAndMultiCharParam()
        {
        }
    }

    public class SingleGenericClassCrefWithltAndBracket<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="S ingleGenericClassCrefWithltAndBracket&lt;T>" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltAndBracket()
        {
        }
    }

    public class SingleGenericClassCrefWithltAndBracketAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref=" CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithltAndBracketAndNamespace&lt;T>" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltAndBracketAndNamespace()
        {
        }
    }

    public class SingleGenericClassCrefWithCurlies<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithCurlies{T} " /> class.
        /// </summary>
        public SingleGenericClassCrefWithCurlies()
        {
        }
    }

    public class SingleGenericClassCrefWithCurliesAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithCurliesAndNamespace`1" /> class.
        /// </summary>
        public SingleGenericClassCrefWithCurliesAndNamespace()
        {
        }
    }

    public class SingleGenericClassCrefWithHardcodedRef<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SingleGenericClassCrefWithHardcodedRef`2" /> class.
        /// </summary>
        public SingleGenericClassCrefWithHardcodedRef()
        {
        }
    }

    public class SingleGenericClassCrefWithHardcodedRefAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithHardcodedRefAndNamespace" /> class.
        /// </summary>
        public SingleGenericClassCrefWithHardcodedRefAndNamespace()
        {
        }
    }

    public class MultiGenericClass<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the MultiGenericClass&lt;T,S,R&gt; class.
        /// </summary>
        public MultiGenericClass()
        {
        }
    }

    public class MultiGenericClassWithNamespace<T, S, R>
    {
        /// <summary>
        /// Initializesa new instance of the CSharpAnalyzersTest.TestData.MultiGenericClassWithNamespace class.
        /// </summary>
        public MultiGenericClassWithNamespace()
        {
        }
    }

    public class MultiGenericClassWithMultiCharParams<TItem, SItem, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the T:MultiGenericClassWithMultiCharParams`3 class.
        /// </summary>
        public MultiGenericClassWithMultiCharParams()
        {
        }
    }

    public class MultiGenericClassCrefWithltgt<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgt&lt;S,T,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgt()
        {
        }
    }

    public class MultiGenericClassCrefWithltgtAndSpaceOne<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgtAndSpaceOnelt;T, S,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndSpaceOne()
        {
        }
    }

    public class MultiGenericClassCrefWithltgtAndSpaceTwo<T, S, R> //*
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgtAndSpaceTwo&lt;T,S, Rgt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndSpaceTwo()
        {
        }
    }

    public class MultiGenericClassCrefWithltgtAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData. MultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithltAndBracket<T, S, R>
    {
        /// <summary>
        /// Initializes    a new instance of the <see cref = "MultiGenericClassCrefWithltAndBracket&lt;T,S,R>" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltAndBracket()
        {
        }
    }

    public class MultiGenericClassCrefWithltAndBracketAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithltAndBracketAndNamespace&lt;T, S, R" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltAndBracketAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithCurlies<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesT,S,R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurlies()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndMultiCharParams<TItem, SItem, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndMultiCharParams{TItem, SItem RItem}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndMultiCharParams()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndSpaceOne<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndSpaceOne{T, S,R" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndSpaceOne()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndSpaceTwo<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see crsef="MultiGenericClassCrefWithCurliesAndSpaceTwo{T,S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndSpaceTwo()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.MultiGenericClassCsdfrefWithCurliesAndNamespace{T, S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRef<T, S, R>
    {
        /// <summary>
        /// IInitializes a new instance of the <see cref="T:MultiGenericClassCrefWithHardcodedRef`3" /> class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRef()
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRefAndNamespace<T, S, R>
    {
        /// <summary>
        /// initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithHardcodedRefAndNamespace`3" /> class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRefAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRefAndMultiCharParams<TItem, S, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MultiGenericClassCrefWithHardcodedRefAndMultiCharParams`3" /> Class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRefAndMultiCharParams()
        {
        }
    }

    public class NestedMultiGenericClassCrefWithltgtAndNamespace<T, S, R>
    {
        public class NestedMultiGenericClassCrefWithltgtAndNamespaceClass2<D, E, F>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NestedMultiGenericClassCrefWithltgtAndNamespaceClass2&lt;D,E,F&gt;" /> class.
            /// </summary>           
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass2()
            {
            }
        }

        public class NestedMultiGenericClassCrefWithltgtAndNamespaceClass3<G, H>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NestedMultiGenericClassCrefWithltgtAndNamespace.NestedMultiGenericClassCrefWithltgtAndNamespaceClass3&lt;G,H&gt;" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass3()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:NestedMultiGenericClassCrefWithltgtAndNamespace`3.NestedMultiGenericClassCrefWithltgtAndNamespaceClass3`3" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass3(int i)
            {
            }
        }
    }
}
