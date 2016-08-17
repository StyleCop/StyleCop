namespace Experiments
{
    using System.Collections.Generic;

    public class StyleCopSyntaxException
    {
        public void Foobar()
        {
            MD5Dictionary<Document>.Key key = MD5Dictionary<Document>.Generate(filePath);
        }
    }
}