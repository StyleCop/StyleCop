namespace Experiments
{
    using System.Collections.Generic;

    public class StyleCopSyntaxException
    {
        private HashSet<string>.Enumerator myEnumerator;

        public void Foobar()
        {
            HashSet<string>.Enumerator anotherEnumerator;
        }
    }
}