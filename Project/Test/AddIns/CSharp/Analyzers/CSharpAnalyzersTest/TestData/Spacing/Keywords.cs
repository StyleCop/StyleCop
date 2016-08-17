namespace CSharpAnalyzersTest.TestData.Spacing
{
    using System.Linq;

    public class Keywords
    {
        /// <summary>
        /// By keyword spacing incorrect
        /// </summary>
        public void Method1()
        {
            int[] values = new[] { 1 };
            var values2 = from x in values
                          group x by(x) into g
                          select g;
        }

        /// <summary>
        /// Group spacing incorrect
        /// </summary>
        public void Method2()
        {
            int[] values = new[] { 1 };
            var values2 = from x in values
                          group(x) by x into g
                          select g;
        }

        /// <summary>
        /// In spacing incorrect
        /// </summary>
        public void Method3()
        {
            int[] values = new[] { 1 };
            var values2 = from x in(values)
                          group x by x into g 
                          select g;
        }

        /// <summary>
        /// Select spacing incorrect
        /// </summary>
        public void Method4()
        {
            int[] values = new[] { 1 };
            var values2 = from x in values
                          group x by x into g
                          select(g);
        }

        /// <summary>
        /// On spacing incorrect
        /// </summary>
        public void Method5()
        {
            nt[] values = new[] { 1 };
            var values2 = from x in values
                          join p in values on(x.ToString()) equals (p.ToString())
                          select Tuple.Create(x, p);
        }

        /// <summary>
        /// Equals spacing incorrect
        /// </summary>
        public void Method6()
        {
            nt[] values = new[] { 1 };
            var values2 = from x in values
                          join p in values on (x.ToString()) equals(p.ToString())
                          select Tuple.Create(x, p);
        }
    }
}
