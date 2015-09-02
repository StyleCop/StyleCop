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
namespace Micr\u006Fs\u006fft.StyleCop.CSh\u0061rp
{
}

// Names prefixing with "at" sign together with Unicode character escape sequence.
namespace @Micr\u006Fs\u006fft.@StyleCop.CSh\u0061rp
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
        char ch\u0061racter = '\u0078';

        void Meth\u006Fd1()
        {
            string local = "St\u0079leCop";
        }
    }
}
