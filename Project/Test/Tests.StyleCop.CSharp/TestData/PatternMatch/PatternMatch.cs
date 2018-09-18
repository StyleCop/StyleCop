namespace Tests.StyleCop.CSharp.TestData.PatternMatch
{
    public class PatternMatch
    {
        public void PatternMatchIfConstruct(object o)
        {
            if (o is null) return;          // constant pattern "null"

            if (o is "SomeString") return;  // constant pattern string

            if (o is 333) return;           // constant pattern integer

            if (o is true) return;          // constant pattern boolean true

            if (o is false) return;         // constant pattern boolean false

            if (!(o is int i)) return;      // type pattern "int i"

            if (o is var v) return;         // var pattern 

            if (o is int i || (o is string s && int.TryParse(s, out i))) { /* use i */ }

            if (o is string) return;        // regression check
        }

        public void PatternMatchIsExpressions(object o)
        {
            bool check = o is null;           // constant pattern "null"

            bool check1 = o is "SomeString";  // constant pattern string

            bool check2 = o is 333;           // constant pattern integer

            bool check3 = o is true;          // constant pattern boolean true

            bool check4 = o is false;         // constant pattern boolean false

            bool check5 = o is int i;         // type pattern "int i"

            bool check6 = o is var v;         // var pattern 

            bool check7 = (o is int i || (o is string s && int.TryParse(s, out i)));

            bool check8 = o is int;           // regression check
        }

        public void PatternMatchSwitchConstruct()
        {            
            switch(shape)
            {
                case null:
                    break;
                case "SomeString":
                    break;
                case 333:
                    break;
                case true:
                    break;
                case false:
                    break;
                case int i:
                    break;
                case Circle c:
                    break;
                case Rectangle s when (s.Length == s.Height):
                    break;
                case Rectangle s when s.Length > s.Height:
                    break;
                case Rectangle r:
                    break;
                case shape.Something when someBoolean:
                    break;
                case IEnumerable<int> ieInt:
                    break;
                default:
                    break;
            }
        }
    }
}
