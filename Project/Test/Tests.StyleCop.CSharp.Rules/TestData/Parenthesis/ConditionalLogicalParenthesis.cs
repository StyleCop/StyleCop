namespace Parenthesis1
{
    using System;

    public class Class1
    {
        public void Method()
        {
            // Invalid
            bool a = 2 != this.Whatever || this.Whatever.Something() - 2 > 0 && x <= 3;

            // Valid
            bool b = (2 != this.Whatever || this.Whatever.Something() - 2 > 0) && x <= 3;

            // Valid
            bool c = 2 != this.Whatever || (this.Whatever.Something() - 2 > 0 && x <= 3);

            // Valid
            bool d = 2 != this.Whatever || this.Whatever.Something() - 2 > 0 || x <= 3;

            // Valid
            bool e = 2 != this.Whatever && this.Whatever.Something() - 2 > 0 && x <= 3;
        }
    }
}
