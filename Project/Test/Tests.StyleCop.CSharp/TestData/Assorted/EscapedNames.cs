// Usual name.
namespace StyleCop.CSharp
{
}

// Name prefixed with "at" sign.
namespace @StyleCop.CSharp
{
}

// Names prefixed with "at" sign.
namespace StyleCop.@CSharp
{
}

// Using Unicode character escape sequence (upper-cased and lower-cased).
namespace Sty\u006CeC\u006fp.CSh\u0061rp
{
}

// Using Unicode character escape sequence (long syntax).
namespace Sty\U0000006CeC\U0000006fp.CSh\U00000061rp
{
}

// Names prefixing with "at" sign together with Unicode character escape sequence.
namespace @Sty\U0000006CeC\U0000006fp.@CSh\u0061rp
{
}

// Escaped names should be applied to:
// - identifiers
// - charater literals
// - regular string literals
namespace StyleCop.CSharp
{
    class Cl\u0061ss1<TK\u0065y> where TKe\u0079 : IDisposa\u0062le
    {
        string v\u0061riable = "StyleC\u006Fp";
        char ch\U00000061racter = '\U00000078';

        void Meth\u006Fd1()
        {
            string local = "St\u0079leCop";
        }
    }
}
