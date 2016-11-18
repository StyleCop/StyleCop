namespace StyleCop.CSharpParserTest.TestData.Elements.PreProcessorDirectives3
{
    ///////////////////////////////////////////////////////////
#if A
    class A             // skipped
    { }                 // skipped
#else
    class A
    { }
#endif

    ///////////////////////////////////////////////////////////
#if !B
    class B
    { }
#else 
    class B             // skipped 
    { }                 // skipped
#endif

    ///////////////////////////////////////////////////////////
#if !C
    class C
    { }
#elif C
    class C             // skipped 
#elif !C
    class C             // skipped 
#else
    class C             // skipped
#endif

    ///////////////////////////////////////////////////////////
#if D
    class D             // skipped
#elif D
    class D             // skipped
#elif !D
    class D
#else
    class D             // skipped
#endif
    { }

    ///////////////////////////////////////////////////////////
#if E 
    class E             // skipped
#elif E
    class E             // skipped
#elif K
    class E             // skipped
#else
    class E
#endif
    { }
    ///////////////////////////////////////////////////////////

#if !F
    class F
    {
        void F1()
        {
        }
#else 
        void F()        // skipped 
        {               // skipped
#if !F
            NotBaz();   // skipped
#elif !F
            var e = ""; // skipped
#else
            Baz();      // skipped
#endif
            return 1;   // skipped 
        }               // skipped

        int BarC()      // skipped
        {               // skipped
#if !F 
            NotBaz();   // skipped
#else
            Baz();      // skipped
#endif
            return 2;   // skipped
        }               // skipped
#endif
    }

    ///////////////////////////////////////////////////////////
    class G
    {
#if G
        int BarD()      // skipped
        {               // skipped
            return 1;   // skipped
        }               // skipped
#else
        int BarE()
        {
#if !G
            var e = "";
#else
            Baz();      // skipped
#endif
            return 1;
        }

        int BarF()
        {
#if G
            NotBaz();   // skipped
#else
            var s = "";
#endif
            return 2;
        }
#endif
    }

    ///////////////////////////////////////////////////////////
    class H
    {
#if H
        int BarA()      // skipped
        {               // skipped
            return 1;   // skipped
        }               // skipped
#else
        int BarB()
        {
#if H
            NotBaz();   // skipped
#else
            var s = "";
#endif
            return 1;
        }

        int BarC()
        {
#if !H
            var s = "";
#else
            Baz();      // skipped
#endif
            return 2;
        }
#endif
    }
}

///////////////////////////////////////////////////////////
#if I
    class I             // skipped
#elif !I
class I
#elif I
    class I             // skipped
#else
    class I             // skipped
#endif
{ }
///////////////////////////////////////////////////////////
