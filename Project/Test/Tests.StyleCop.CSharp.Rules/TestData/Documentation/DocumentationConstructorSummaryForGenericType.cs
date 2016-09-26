using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class SimpleClass
    {
        /// <summary>
        /// Initializes a new instance of the SimpleClass class.
        /// </summary>
        public SimpleClass()
        {
        }
    }

    public class SimpleClassWithCref
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClassWithCref" /> class.
        /// </summary>
        public SimpleClassWithCref()
        {
        }
    }

    public class SimpleClassWithNamespace
    {
        /// <summary>
        /// Initializes a new instance of the CSharpAnalyzersTest.TestData.SimpleClassWithNamespace class.
        /// </summary>
        public SimpleClassWithNamespace()
        {
        }
    }

    public class SimpleClassWithNamespaceAndCref
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SimpleClassWithNamespaceAndCref" /> class.
        /// </summary>
        public SimpleClassWithNamespaceAndCref()
        {
        }
    }

    public class SingleGenericClass<T>
    {
        /// <summary>
        /// Initializes a new instance of the SingleGenericClass class.
        /// </summary>
        public SingleGenericClass()
        {
        }
    }

    public class SingleGenericClassWithNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the CSharpAnalyzersTest.TestData.SingleGenericClassWithNamespace class.
        /// </summary>
        public SingleGenericClassWithNamespace()
        {
        }
    }

    public class SingleGenericClassWithMultiCharParam<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the SingleGenericClassWithMultiCharParam class.
        /// </summary>
        public SingleGenericClassWithMultiCharParam()
        {
        }
    }

    public class SingleGenericClassCrefWithltgt<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithltgt&lt;T&gt;" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgt()
        {
        }
    }

    public class SingleGenericClassCrefWithltgtAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithltgtAndNamespace&lt;T&gt;" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgtAndNamespace()
        {
        }
    }

    public class SingleGenericClassCrefWithltgtAndMultiCharParam<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithltgtAndMultiCharParam&lt;TItem&gt;" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltgtAndMultiCharParam()
        {
        }
    }

    public class SingleGenericClassCrefWithltAndBracket<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithltAndBracket&lt;T>" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltAndBracket()
        {
        }
    }

    public class SingleGenericClassCrefWithltAndBracketAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithltAndBracketAndNamespace&lt;T>" /> class.
        /// </summary>
        public SingleGenericClassCrefWithltAndBracketAndNamespace()
        {
        }
    }

    public class SingleGenericClassCrefWithCurlies<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleGenericClassCrefWithCurlies{T}" /> class.
        /// </summary>
        public SingleGenericClassCrefWithCurlies()
        {
        }
    }

    public class SingleGenericClassCrefWithCurliesAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithCurliesAndNamespace{T}" /> class.
        /// </summary>
        public SingleGenericClassCrefWithCurliesAndNamespace()
        {
        }
    }
    
    public class SingleGenericClassCrefWithHardcodedRefAndNamespace<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.SingleGenericClassCrefWithHardcodedRefAndNamespace`1" /> class.
        /// </summary>
        public SingleGenericClassCrefWithHardcodedRefAndNamespace()
        {
        }
    }

    public class MultiGenericClass<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the MultiGenericClass class.
        /// </summary>
        public MultiGenericClass()
        {
        }
    }

    public class MultiGenericClassWithNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the CSharpAnalyzersTest.TestData.MultiGenericClassWithNamespace class.
        /// </summary>
        public MultiGenericClassWithNamespace()
        {
        }
    }

    public class MultiGenericClassWithMultiCharParams<TItem, SItem, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the MultiGenericClassWithMultiCharParams class.
        /// </summary>
        public MultiGenericClassWithMultiCharParams()
        {
        }
    }

    public class MultiGenericClassCrefWithltgt<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgt&lt;T,S,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgt()
        {
        }
    }

    public class MultiGenericClassCrefWithltgtAndSpaceOne<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgtAndSpaceOne&lt;T, S,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndSpaceOne()
        {
        }
    }

    public class MultiGenericClassCrefWithltgtAndSpaceTwo<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltgtAndSpaceTwo&lt;T,S, R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndSpaceTwo()
        {
        }
    }
    
    public class MultiGenericClassCrefWithltgtAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltgtAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithltAndBracket<T,S,R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithltAndBracket&lt;T,S,R>" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltAndBracket()
        {
        }
    }

    public class MultiGenericClassCrefWithltAndBracketAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithltAndBracketAndNamespace&lt;T, S, R>" /> class.
        /// </summary>
        public MultiGenericClassCrefWithltAndBracketAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithCurlies<T,S,R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurlies{T,S,R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurlies()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndMultiCharParams<TItem,SItem, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndMultiCharParams{TItem, SItem,RItem}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndMultiCharParams()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndSpaceOne<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndSpaceOne{T, S,R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndSpaceOne()
        {
        }
    }

    public class MultiGenericClassCrefWithCurliesAndSpaceTwo<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndSpaceTwo{T,S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndSpaceTwo()
        {
        }
    }
    
    public class MultiGenericClassCrefWithCurliesAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithCurliesAndNamespace{T, S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndNamespace()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestData.MultiGenericClassCrefWithCurliesAndNamespace{T, S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndNamespace(int a)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiGenericClassCrefWithCurliesAndNamespace{T, S, R}" /> class.
        /// </summary>
        public MultiGenericClassCrefWithCurliesAndNamespace(int a, int b)
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRef<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithHardcodedRef`3" /> class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRef()
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRefAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithHardcodedRefAndNamespace`3" /> class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRefAndNamespace()
        {
        }
    }

    public class MultiGenericClassCrefWithHardcodedRefAndMultiCharParams<TItem, S, RItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.MultiGenericClassCrefWithHardcodedRefAndMultiCharParams`3" /> class.
        /// </summary>
        public MultiGenericClassCrefWithHardcodedRefAndMultiCharParams()
        {
        }
    }

    public class NestedMultiGenericClassCrefWithltgtAndNamespace<T, S, R>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.NestedMultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;" /> class.
        /// </summary>
        public NestedMultiGenericClassCrefWithltgtAndNamespace()
        {
        }

        public class NestedMultiGenericClassCrefWithltgtAndNamespaceClass1<A, B, C>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CSharpAnalyzersTest.TestData.NestedMultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;.NestedMultiGenericClassCrefWithltgtAndNamespaceClass1&lt;A,B,C&gt;" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NestedMultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;.NestedMultiGenericClassCrefWithltgtAndNamespaceClass1&lt;A,B,C&gt;" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass1()
            {
            }

            public class NestedMultiGenericClassCrefWithltgtAndNamespaceClass4<D, E>
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="NestedMultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;.NestedMultiGenericClassCrefWithltgtAndNamespaceClass1&lt;A,B,C&gt;.NestedMultiGenericClassCrefWithltgtAndNamespaceClass4&lt;D,E&gt;" /> class.
                /// </summary>
                public NestedMultiGenericClassCrefWithltgtAndNamespaceClass4()
                {
                }
            }
        }      

        public class NestedMultiGenericClassCrefWithltgtAndNamespaceClass3<G, H>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NestedMultiGenericClassCrefWithltgtAndNamespace&lt;T,S,R&gt;.NestedMultiGenericClassCrefWithltgtAndNamespaceClass3&lt;G,H&gt;" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass3()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:CSharpAnalyzersTest.TestData.NestedMultiGenericClassCrefWithltgtAndNamespace`3.NestedMultiGenericClassCrefWithltgtAndNamespaceClass3`2" /> class.
            /// </summary>
            public NestedMultiGenericClassCrefWithltgtAndNamespaceClass3(int i)
            {
            }
        }
    }
}
