namespace Parenthesis1
{
    using System;

    public class Class1
    {
        public void Invalid()
        {
            int a = 2 + (y - this.Whatever + this.Whatever.Something()) * 2;
            int b = 2 % y + this.Whatever + this.Whatever.Something() - 2;
            int c = 2 + y * this.Whatever + this.Whatever.Something() - 2;
            int d = 2 + y + this.Whatever / this.Whatever.Something() - 2;
            int e = 2 + y + this.Whatever + this.Whatever.Something() >> 2;
            int f = 2 + y + this.Whatever + this.Whatever.Something() - 2 << Item;
            int g = 2 * y / this.Whatever % this.Whatever.Something() >> 2 << Item;
            int h = 2 * (y / this.Whatever) % (this.Whatever.Something() >> (2 << Item));
        }

        public void Valid()
        {
            int a = 2 + (y + this.Whatever) + (this.Whatever.Something() - 2);
            int b = (2 % y) + this.Whatever + this.Whatever.Something() - 2;
            int c = 2 + (y * this.Whatever) + this.Whatever.Something() - 2;
            int d = 2 + y + (this.Whatever / this.Whatever.Something()) - 2;
            int e = 2 + y + this.Whatever + (this.Whatever.Something() >> 2);
            int f = 2 + y + this.Whatever + this.Whatever.Something() - (2 << Item);
            int g = (2 * (y / this.Whatever)) % (this.Whatever.Something() >> (2 << Item));

            int h = 2 * 4 * 6;
            int i = 2 * 4 / 6;
            int j = 2 / 4 * 6;
            int k = 2 / 4 / 6;
            int l = 2 + 4 + 6;
            int m = 2 + 4 - 6;
            int n = 2 - 4 + 6;
            int o = 2 - 4 - 6;
            int p = 2 >> 4 >> 6;
            int q = 2 >> 4 << 6;
            int r = 2 << 4 >> 6;
            int s = 2 << 4 << 6;
        }
    }
}
